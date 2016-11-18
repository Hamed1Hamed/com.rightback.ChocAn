using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services.Reports;

namespace com.rightback.ChocAn.Services.Services
{
    public class BenefitService : BaseService, IBenefitService
    {
        private IReportService reportService = new ReportService();

        public List<Service> getAllServices()
        {
            return db.Services
                .OrderBy(s=>s.Name)
                .ToList();
        }

        public Service getServiceByCode(string serviceCode)
        {
            return db.Services
                 .Where(s => s.Code.Equals(serviceCode))
                 .FirstOrDefault();
        }
      

        /// <summary>
        /// Current implementation saves it to the file.
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <returns></returns>
        public String sendServiceDirectory(string providerNumber)
        {
            Provider provider = db.Providers
                .Where(p => p.Code.Equals(providerNumber))
                .FirstOrDefault();

            if (provider == null)
                return "Invalid provider";

            List<Service> allServices = this.getAllServices();

            List<ServiceReportItem> serializableServices = new List<ServiceReportItem>();
            foreach (Service service in allServices)
                serializableServices.Add(new ServiceReportItem(service));

            String result = String.Empty;
            try
            {
                this.reportService.writeServiceDirectory(provider, serializableServices);
            }
            catch(Exception ex)
            {
                result = "An error occurred." + ex.Message;

            }
            return result;
            
        }

    }
}
