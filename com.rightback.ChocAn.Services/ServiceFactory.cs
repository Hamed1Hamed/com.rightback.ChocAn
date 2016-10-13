using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services
{
    public static class ServiceFactory
    {

        public static IMemberService getMemberService()
        {
            //todo!
            //return new MemberService();
            throw new NotImplementedException();
        }


        public static IProviderService getProviderService()
        {
            return new ProviderService();
        }

        
    }
}
