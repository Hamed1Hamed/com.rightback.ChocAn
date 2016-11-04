using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;
using System.Data;
using com.rightback.ChocAn.Services.Services;
using com.rightback.ChocAn.DAL.Entities;

namespace com.rightback.ChocAn.Services.Reports
{
    public class ReportService : IReportService
    {
        public void writeServiceDirectory(Provider provider, List<ServiceReportItem> services)
        {
            string fileName = String.Format("ServiceDirectory_{0}_{1:MM-dd-yyyy}", provider.Name.Replace(" ", "-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            DataTable dt = IquerableConverter.ListToDataTable(services);
            ReportWriter.CreateCSVFile(dt, filePath + "txt");
            ReportWriter.CreateHtmlFile(dt, filePath + "html");
        }

        public void writeServiceDirectory(Person person, List<ServiceReportItem> services)
        {

            if (person is Provider)
                writeServiceDirectory( person, services);
            if (person is Member)
                writeServiceDirectory(person, services);
        }
        public void writeServiceDirectory(Member member, List<ServiceReportItem> services)
        {
            string fileName = String.Format("ServiceDirectory_{0}_{1:MM-dd-yyyy}", member.Name.Replace(" ", "-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            DataTable dt = IquerableConverter.ListToDataTable(services);
            ReportWriter.CreateCSVFile(dt, filePath + "txt");
            ReportWriter.CreateHtmlFile(dt, filePath + "html");
        }
    }
}
