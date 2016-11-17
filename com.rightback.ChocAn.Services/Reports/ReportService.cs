using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;
using System.Data;
using com.rightback.ChocAn.Services.Services;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.Services.Helpers;

namespace com.rightback.ChocAn.Services.Reports
{
    public class ReportService : IReportService
    {
        public void writeEFTData(Provider provider,string content)
        {
            string fileName = String.Format("EFT_{0}_{1:MM-dd-yyyy}", provider.Name.Replace(" ", "-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            ReportWriter.CreateFile(content, filePath+ ".txt");
        }


        public void writeServiceDirectory(Provider provider, List<ServiceReportItem> services)
        {
            string fileName = String.Format("ServiceDirectory_{0}_{1:MM-dd-yyyy}", provider.Name.Replace(" ", "-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            DataTable dt = DataConversion.ToDataTable(services);
            //you can activate next line to do CSV file
           // ReportWriter.CreateCSVFile(dt, filePath + ".txt");
            ReportWriter.CreateHtmlFile(dt, filePath + ".html");
        }

        public void writeSummaryReport(string report)
        {
            string fileName = String.Format("SummaryReport_{0:MM-dd-yyyy}", DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            ReportWriter.CreateFile(report, filePath + ".txt");
        }

        public void writeWeeklyStatment(Person person,String statment)
        {
            string fileName = String.Format("WeeklyStatment_{0}_{1:MM-dd-yyyy}", person.Name.Replace(" ", "-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            ReportWriter.CreateFile(statment, filePath + ".html");
        }


    }
}
