using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;

namespace com.rightback.ChocAn.Services.Providers
{
    public class ProviderService : BaseService, IProviderService
    {
        public void deleteProvider(string code)
        {
            if (code == null)
                throw new ArgumentNullException();
            var provider = db.Providers.Where(m => m.Code.Equals(code)).FirstOrDefault();
            if (provider != null)
            {
                db.Providers.Remove(provider);
                db.SaveChanges();
            }
            else
                throw new KeyNotFoundException();

        }

        public DbSet<Provider> getAllProviders()
        {
            return db.Providers;
        }

        public Provider getByCode(string code)
        {
            if (code == null)
                throw new ArgumentNullException();
            return db.Providers
                .Where(p => p.Code == code)
                .FirstOrDefault();
        }

        public Provider getById(int Id)
        {
            return db.Providers
               .Where(p => p.ProviderID == Id)
               .FirstOrDefault();
        }

        public void upsertProvider(Provider provider)
        {
            if (provider == null)
                throw new ArgumentNullException();
            if (provider.Code == null)
                throw new ArgumentNullException();
            var providerSearch = getByCode(provider.Code);
            if (providerSearch == null)
            {
                db.Providers.Add(provider);
            }
            else
            {
                //using AddOrUpdate method is not safe as it may insert dublicate records
                providerSearch.City = provider.City;
                providerSearch.Email = provider.Email;
                providerSearch.Name = provider.Name;
                providerSearch.Zip = provider.Zip;
                providerSearch.TerminalCode = provider.TerminalCode;
                providerSearch.StreetAddres = provider.StreetAddres;
            }
            db.SaveChanges();
        }

      
    }
}
