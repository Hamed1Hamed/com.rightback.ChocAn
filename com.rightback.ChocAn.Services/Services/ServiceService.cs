using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;

namespace com.rightback.ChocAn.Services.Services
{
    public class ServiceService : BaseService, IServiceService
    {
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
        public IQueryable<Claim> getClaimsWithin(DateTime start, DateTime end)
        {
            return from u in db.Claims.Where(e => e.DateOfClaim > start & e.DateOfClaim < end) select u;
        }

    }
}
