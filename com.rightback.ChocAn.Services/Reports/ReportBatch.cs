using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.rightback.ChocAn.Services
{
    public class ReportBatch
    {
        public static void ScheduleTask()
        {
            if (!checkIfLastReportWasGenerated())
            {
                int daysToOffset = (((int)DayOfWeek.Friday - (int)DateTime.Now.DayOfWeek + 7) % 7) * -1;
                DateTime lastFridayOfLastCompletedWeek = DateTime.Now.AddDays(daysToOffset);
                int day = lastFridayOfLastCompletedWeek.Date.Day;
                int month= lastFridayOfLastCompletedWeek.Date.Month;
                int year = lastFridayOfLastCompletedWeek.Date.Year;
                runBatch(year,month,day);
            }
              
            // This finds the next Friday (or today if it's Friday) and then adds a day... so the
            // result is in the range [0-6]
                int daysUntilFriday = (((int)DayOfWeek.Friday - (int)DateTime.Now.DayOfWeek + 7) % 7) ;

            if (daysUntilFriday > 0)
            {
                const int hrToMs = 60 * 60 * 1000;
                //waits certan time and run the code
                Task.Delay(hrToMs).Wait();
                ScheduleTask();
            }
            else
            {
                while (DateTime.Now.TimeOfDay.Hours!=1)
                    Task.Delay(1000).Wait();
                runBatch(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

      
        private static bool checkIfLastReportWasGenerated()
        {

            int daysToOffset = (((int)DayOfWeek.Friday - (int)DateTime.Now.DayOfWeek + 7) % 7) * -1;
            DateTime lastFridayOfLastCompletedWeek = DateTime.Now.AddDays(daysToOffset);
           int dayOfYear= lastFridayOfLastCompletedWeek.Date.DayOfYear;
            int year = lastFridayOfLastCompletedWeek.Date.Year;

            bool isSuccessful=false;
            using (var context = new ChocAnDBModel())
            {
                // Perform data access using the context 
                var entry = context.Batches.FirstOrDefault(e => e.DayOfYear == dayOfYear & e.Year == year);
                if (entry != null)
                    isSuccessful = true;
            }

            return isSuccessful;

        }
        private static void runBatch(int year, int month,int day)
        {
            DateTime end = new DateTime(year,month,day);
            DateTime start = end.AddDays(-7);

            Services.IServiceService services = new ServiceService();
            var claims = services.getClaimsWithin(start, end);

            Emails.IEmailService emailServer = new Emails.EmailService();

            foreach (Member m in from u in claims select u.Member)
            {
                var memberClaims= claims.Where(e => e.Member.MemberID == m.MemberID);
                var message = Helpers.DataConversion.ConvertDataTableToHTML(IquerableConverter.ToDataTable(memberClaims.ToList()));
                //send email
                emailServer.sendEmail("no-reply@ChocAn.com",m.Email,"ChocAn Statment", message);
             
            }
            foreach (Provider  p in from u in claims select u.Provider)
            {
                var providerClaims = claims.Where(e => e.Member.MemberID == p.ProviderID);
                var message = Helpers.DataConversion.ConvertDataTableToHTML(IquerableConverter.ToDataTable(providerClaims.ToList()));
                //send email
                emailServer.sendEmail("no-reply@ChocAn.com", p.Email, "ChocAn Statment", message);
                //send email

            }
            //store
           // ReportWriter.CreateHtmlFile()

            using (var context = new ChocAnDBModel())
            {
                // save batch details in the DB
                int dayOfYear = end.DayOfYear;
                Batch batchEntry = new Batch{ DayOfYear = dayOfYear, Year = year };
                context.Batches.Add(batchEntry);
                context.SaveChanges();
                
            }
        }
    }
}