using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Services
{
    /// <summary>
    /// Serializable class for service class to be used to convert 
    /// service lists to datatable etc-like serializable structures.
    /// </summary>
    public class ServiceReportItem
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Fee { get; set; }

        public ServiceReportItem(Service service)
        {
            this.Name = service.Name;
            this.Code = service.Code;
            this.Fee = service.Fee;

        }
    }
}
