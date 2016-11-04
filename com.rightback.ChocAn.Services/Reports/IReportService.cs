using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Reports
{
    public interface IReportService
    {
        /// <summary>
        /// Writes service directory for provider to a file.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="services"></param>
        void writeServiceDirectory(Provider provider, List<ServiceReportItem> services);
        /// <summary>
        /// Writes service directory for person to a file.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="services"></param>
        void writeServiceDirectory(Person person, List<ServiceReportItem> services);
        /// <summary>
        /// Writes service directory for member to a file.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="services"></param>
        void writeServiceDirectory(Member member, List<ServiceReportItem> services);
    }
}
