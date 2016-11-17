﻿using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.Services.Claims;
using com.rightback.ChocAn.Services.Extensions;
using com.rightback.ChocAn.Services.Helpers;
using com.rightback.ChocAn.Services.Reports;
using com.rightback.ChocAn.Services.Services;
using System;
using System.Collections.Generic;
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
            IClaimService ClaimService = new ClaimService();
            var claims = ClaimService.getClaimsWithin(start, end);
            Emails.IEmailService emailServer = new Emails.EmailService();
            Reports.IReportService Writer = new Reports.ReportService();
            Claims.IClaimService claimService = new Claims.ClaimService();

            foreach (Member m in from u in claims select u.Member)
            {
                processMemberWeeklyStatement(m, claims, emailServer, Writer);
            }
            foreach (Provider p in from u in claims select u.Provider)
            {
                processProviderWeeklyStatement(p, claims, emailServer, Writer);
                processEFT(p, claims, Writer);
            }

            processWeeklySumarryReort(claims);

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

        private static void processWeeklySumarryReort(IQueryable<Claim> claimInWeek)
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
            IReportService reportService = new ReportService();
            reportService.writeSummaryReport(firstLine + seconedtLine + thirdLine);

        }
        private static void processMemberWeeklyStatement(Member m, IQueryable<Claim> claims, Emails.IEmailService emailServer, Reports.IReportService Writer)
        {
            Claims.IClaimService claimService = new Claims.ClaimService();
            int personId;
            IQueryable<Claim> personClaims = null;
            string statement = "";
            personId = m.MemberID;
            personClaims = claims.Where(e => e.Member.MemberID == personId);
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

        private static void processProviderWeeklyStatement(Provider p, IQueryable<Claim> claims, Emails.IEmailService emailServer, Reports.IReportService Writer)
        {
            Claims.IClaimService claimService = new Claims.ClaimService();
            int personId;
            IQueryable<Claim> personClaims = null;
            string statement = "";
            personId = (p as Provider).ProviderID;
            personClaims = claims.Where(e => e.Provider.ProviderID == personId);
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
        private static void processEFT(Provider p, IQueryable<Claim> claims, Reports.IReportService Writer)
        {
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