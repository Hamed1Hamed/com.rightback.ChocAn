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
        List<Provider> getAllProviders();
    }
}
