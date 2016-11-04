using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;
using System.Data;
using com.rightback.ChocAn.Services.Services;

namespace com.rightback.ChocAn.Services.Reports
{
    public class ReportService : IReportService
    {
        public void writeServiceDirectory(Provider provider, List<ServiceReportItem> services)
        {
            string fileName = String.Format("ServiceDirectory_{0}_{1:MM-dd-yyyy}.txt", provider.Name.Replace(" ","-"), DateTime.Now);
            string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/" + fileName);
            DataTable dt = IquerableConverter.ListToDataTable(services);
            ReportWriter.CreateCSVFile(dt, filePath);
            ReportWriter.CreateHtmlFile(dt, filePath);

        }
    }
}
