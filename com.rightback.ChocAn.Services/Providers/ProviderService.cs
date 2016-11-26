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

        public IQueryable<Provider> getAllProviders()
        {
            return db.Providers.AsQueryable();
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

        public IQueryable<Provider> getProvidersWhoConsultedWithin(DateTime start, DateTime end)
        {
            return from u in db.Claims.Where(e => e.DateOfClaim > start & e.DateOfClaim < end) select u.Provider;
        }

        public IQueryable<Provider> getProvidersWhoContains(string keyWord)
        {
            return (from u in db.Providers.Where(e => e.Name.Contains(keyWord)
                          || e.Code.Contains(keyWord)
                    || e.Zip.Contains(keyWord)
                    || e.Type.ToString().Contains(keyWord)
                    || e.State.ToString().Contains(keyWord)
                    || e.StreetAddres.Contains(keyWord)
                    || e.Email.Contains(keyWord)
                    || e.City.Contains(keyWord))
                    select u).Distinct();
        }

        public void upsertProvider(Provider provider)
        {
            if (provider == null)
                throw new ArgumentNullException();
            if (provider.Code == null)
                throw new ArgumentNullException("Code", "Member code is missing");
            var providerSearch = getById(provider.ProviderID);
            if (providerSearch == null)
            {
                db.Providers.Add(provider);
            }
            else
            {
                //using AddOrUpdate method is not safe as it may insert dublicate records
                providerSearch.Name = provider.Name;
                providerSearch.City = provider.City;
                providerSearch.Email = provider.Email;
                providerSearch.Zip = provider.Zip;
                providerSearch.TerminalCode = provider.TerminalCode;
                providerSearch.StreetAddres = provider.StreetAddres;
                providerSearch.Code = provider.Code;
                providerSearch.State = provider.State;
                providerSearch.Type = provider.Type;

            }
            db.SaveChanges();
        }

      
    }
}
