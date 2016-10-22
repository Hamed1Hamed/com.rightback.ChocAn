using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Providers
{
    public interface IProviderService
    {
        /// <summary>
        /// Returns all providers in database.
        /// </summary>
        /// <returns></returns>
        DbSet<Provider> getAllProviders();

        /// <summary>
        /// Returns provider by 9 digit provider code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Provider</returns>
        Provider getByCode(string code);

        /// <summary>
        /// Returns provider by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Provider</returns>
        Provider getById(int Id);

        /// <summary>
        /// insert new Provider or update if id existed.
        /// </summary>
        /// <param name="Provider"></param>
        /// <returns></returns>
        void upsertProvider(Provider provider);


        /// <summary>
        ///Delete Provider .
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        void deleteProvider(string code);
    }
}
