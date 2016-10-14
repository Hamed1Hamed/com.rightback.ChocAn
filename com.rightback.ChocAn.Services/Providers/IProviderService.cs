using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
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
        List<Provider> getAllProviders();

        /// <summary>
        /// Returns provider with the provided code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Provider getByCode(string code);
    }
}
