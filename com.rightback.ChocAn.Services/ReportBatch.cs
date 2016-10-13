using com.rightback.ChocAn.DAL;
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
                int dayOfYear = lastFridayOfLastCompletedWeek.Date.DayOfYear;
                int year = lastFridayOfLastCompletedWeek.Date.Year;
                runBatch(year,dayOfYear);
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
                runBatch(DateTime.Now.Year, DateTime.Now.DayOfYear);
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
                var entry = context.Batchs.First(e => e.DayOfYear == dayOfYear & e.Year == year);
                if (entry != null)
                    isSuccessful = true;
            }

            return isSuccessful;

        }
        private static void runBatch(int year, int dayOfYear)
        {
            throw new NotImplementedException();
        }
    }
}