using com.rightback.ChocAn.Services.Emails;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using com.rightback.ChocAn.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.Services.Claims;

namespace com.rightback.ChocAn.Services
{
    public static class ServiceFactory
    {

        public static IMemberService getMemberService()
        {
            return new MemberService();
        }

        public static IProviderService getProviderService()
        {
            return new ProviderService();
        }

        public static IServiceService getServiceService()
        {
            return new ServiceService();
        }

        public static IEmailService getEmailService()
        {
            return new EmailService();
        }

        public static IClaimService getClaimService()
        {
            return new ClaimService();
        }
    }
}
