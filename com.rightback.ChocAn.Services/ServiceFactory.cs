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
using com.rightback.ChocAn.Services.Reports;

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

        public static IBenefitService getBenefitService()
        {
            return new BenefitService();
        }

        public static IEmailService getEmailService()
        {
            return new EmailService();
        }

        public static IClaimService getClaimService()
        {
            return new ClaimService();
        }
        public static IReportService getReportService()
        {
            return new ReportService();
        }

    }
}
