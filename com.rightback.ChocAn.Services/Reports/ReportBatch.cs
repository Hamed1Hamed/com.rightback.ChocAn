using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services.Claims;
using com.rightback.ChocAn.Services.Emails;
using com.rightback.ChocAn.Services.Extensions;
using com.rightback.ChocAn.Services.Helpers;
using com.rightback.ChocAn.Services.Reports;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services
{
   
    public class ReportBatch
    {
        public static async void ScheduleTask()
        {
            if (!checkIfLastReportWasGenerated())
            {
                DateTime batchDate = DateTime.Now.Previous( DayOfWeek.Friday);
                runBatch(batchDate.Year, batchDate.Month, batchDate.Day);
            }
            else if (DateTime.Now.DayOfWeek==DayOfWeek.Friday&DateTime.Now.Hour==13)
            {
                runBatch(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                ScheduleTask();
            }
            else
            {
                await Task.Delay(5*60*100);
                ScheduleTask();
            }         
        }

        private static bool checkIfLastReportWasGenerated()
        {
            DateTime lastFriday = DateTime.Now.Previous( DayOfWeek.Friday);
            int dayOfYear = lastFriday.Date.DayOfYear;
            int year = lastFriday.Date.Year;
            bool isSuccessful = false;
            using (var context = new ChocAnDBModel())
            {
                // Perform data access using the context 
                var entry = context.Batches.Where(e => e.DayOfYear == dayOfYear & e.Year == year).FirstOrDefault();
                if (entry != null)
                    isSuccessful = true;
            }
            return isSuccessful;
        }
      
        private static void runBatch(int year, int month, int day)
        {
            DateTime end = new DateTime(year, month, day);
            DateTime start = end.AddDays(-7);
            IClaimService ClaimService = ServiceFactory.getClaimService();
            var claims = ClaimService.getClaimsWithin(start, end);
            var claimsChecked=ClaimService.getCheckedClaimsWithin(start,end);

            foreach (Member m in from u in claims select u.Member)
            {
                processMemberWeeklyStatement(m, claims);
            }
            foreach (Provider p in from u in claims select u.Provider)
            {
                processProviderWeeklyClaimCheckList(p, claimsChecked);
                processProviderWeeklyStatement(p, claims);
                processEFT(p, claims);
            }

            processWeeklySummaryReport(claims);

            using (var context = new ChocAnDBModel())
            {
                // save batch details in the DB
                int dayOfYear = end.DayOfYear;
                Batch batchEntry = new Batch { DayOfYear = dayOfYear, Year = year };
                context.Batches.Add(batchEntry);
                context.SaveChanges();
            }
            //schedule next report batch
            ScheduleTask();
        }

        private static void processWeeklySummaryReport(IQueryable<Claim> claimInWeek)
        {
            string firstLine = "Total number of providers: "+
                (from u in claimInWeek select u.Provider.ProviderID).Distinct().Count().ToString()+"</br>";
            string seconedtLine = "The total number of consultations: "+
                claimInWeek.Count().ToString()+"</ br >";
            string thirdLine = "Overall fee  The total number of consultations: ";
            if (claimInWeek.Count() > 0)
                thirdLine= thirdLine + claimInWeek.Sum(e => e.Service.Fee).ToString();
            else
                thirdLine = thirdLine + 0;
            IReportService reportService = ServiceFactory.getReportService();
            reportService.writeSummaryReport(firstLine + seconedtLine + thirdLine);

        }
        private static void processMemberWeeklyStatement(Member m, IQueryable<Claim> claims)
        {
            IReportService Writer = ServiceFactory.getReportService();
            IEmailService emailServer = ServiceFactory.getEmailService();
            IClaimService claimService = ServiceFactory.getClaimService();
            int personId;
            string statement = "";
            personId = m.MemberID;
            IQueryable<Claim> personClaims = claims.Where(e => e.Member.MemberID == personId);
            var serializedClaims = claimService.generateSerializedReport(m, personClaims);
            statement = m.generateMemberCoverStatment();
            statement += DataConversion.ConvertDataTableToHTML(DataConversion.ToDataTable(serializedClaims));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(statement));
            //Add a new attachment to the E-mail message, using the correct MIME type
            Attachment attachment = new Attachment(stream, new ContentType("text/plain"));
            attachment.Name = "statment.html";
            //send email
            emailServer.sendEmail("no-reply@ChocAn.com", m.Email, "ChocAn Statment", "Attached your statment for this week.", new Attachment[] { attachment });
            //store file
            Writer.writeWeeklyStatment(m, statement);
        }
        private static void processProviderWeeklyClaimCheckList(Provider p, IQueryable<ClaimCheck> claims)
        {
            IEmailService emailServer = ServiceFactory.getEmailService();
            IClaimService claimService = ServiceFactory.getClaimService();
            int personId;
            string statement = "";
            personId = p.ProviderID;
            IQueryable<ClaimCheck> personClaims = claims.Where(e => e.Provider.ProviderID == personId);
            statement = p.generateProviderCoverStatment(personClaims);
            var serializedClaims = claimService.generateSerializedReport(p, personClaims);
            statement += DataConversion.ConvertDataTableToHTML(DataConversion.ToDataTable(serializedClaims));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(statement));
            //Add a new attachment to the E-mail message, using the correct MIME type
            Attachment attachment = new Attachment(stream, new ContentType("text/plain"));
            attachment.Name = "statment.html";
            //send email
            emailServer.sendEmail("no-reply@ChocAn.com", p.Email, "ChocAn claim check", "Attached your checked claims for this week.", new Attachment[] { attachment });
        }

        private static void processProviderWeeklyStatement(Provider p, IQueryable<Claim> claims)
        {

            IReportService Writer = ServiceFactory.getReportService();
            IEmailService emailServer = ServiceFactory.getEmailService();
            IClaimService claimService = ServiceFactory.getClaimService();
            int personId;
            string statement = "";
            personId = (p as Provider).ProviderID;
            var personClaims = claims.Where(e => e.Provider.ProviderID == personId);
            statement = p.generateProviderCoverStatment(personClaims);
            var serializedClaims = claimService.generateSerializedReport(p, personClaims);
            statement += DataConversion.ConvertDataTableToHTML(DataConversion.ToDataTable(serializedClaims));
            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(statement));
            //Add a new attachment to the E-mail message, using the correct MIME type
            Attachment attachment = new Attachment(stream, new ContentType("text/plain"));
            attachment.Name = "statment.html";
            //send email
            emailServer.sendEmail("no-reply@ChocAn.com", p.Email, "ChocAn Statment", "Attached your statment for this week.", new Attachment[] { attachment });
            //store file
            Writer.writeWeeklyStatment(p, statement);
        }
        private static void processEFT(Provider p, IQueryable<Claim> claims)
        {
            IReportService Writer = ServiceFactory.getReportService();
            if (p == null || claims == null || Writer == null) return;
            int providerId = p.ProviderID;
            var claimsForProvider = claims.Where(e => e.Provider.ProviderID == providerId);
            string data = p.Name + ", " + p.Code;
            decimal amountToTransfer = claimsForProvider.Sum(e => e.Fee);
            data += ", amountToTransfer=" + amountToTransfer;
            Writer.writeEFTData(p, data);
        }
  
    }
}