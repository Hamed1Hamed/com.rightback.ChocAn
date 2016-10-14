using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;

namespace com.rightback.ChocAn.Services.Providers
{
    public class ProviderService : BaseService, IProviderService
    {
        public List<Provider> getAllProviders()
        {
            return db.Providers.ToList();
        }

        public Provider getByCode(string code)
        {
            return db.Providers
                .Where(p => p.Code == code)
                .FirstOrDefault();
        }

        
    }
}
