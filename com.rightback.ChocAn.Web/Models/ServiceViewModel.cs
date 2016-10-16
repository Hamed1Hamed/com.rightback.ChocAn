using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Web.Models
{
    /// <summary>
    /// Serializable class for Service db entity.
    /// Will be used for terminal communication
    /// </summary>
    public class ServiceViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public static ServiceViewModel fromService(Service service)
        {
            return new ServiceViewModel()
            {
                Code = service.Code,
                Name = service.Name
            };
        }

        public static List<ServiceViewModel> fromServiceList(List<Service> serviceList)
        {
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            foreach(Service service in serviceList)
            {
                ServiceViewModel svm = fromService(service);
                result.Add(svm);
            }
            return result;

        }
    }
}
