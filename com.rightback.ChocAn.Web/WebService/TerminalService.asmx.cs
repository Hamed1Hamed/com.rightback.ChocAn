using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Claims;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using com.rightback.ChocAn.Services.Services;
using com.rightback.ChocAn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using static com.rightback.ChocAn.DAL.Member;

namespace com.rightback.ChocAn.Web.WebService
{
    /// <summary>
    /// Summary description for TerminalService
    /// </summary>
    [WebService(Namespace = "http://rightback.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TerminalService : System.Web.Services.WebService
    {
        private IProviderService providerService = ServiceFactory.getProviderService();
        private IMemberService memberService = ServiceFactory.getMemberService();
        private IServiceService serviceService = ServiceFactory.getServiceService();
        private IClaimService claimService = ServiceFactory.getClaimService();

        /// <summary>
        /// Returns true if correct provider code and terminal code provided for the provider.
        /// False otherwise.
        /// </summary>
        /// <param name="providerCode"></param>
        /// <param name="terminalCode"></param>
        /// <returns></returns>
        [WebMethod]
        public bool loginProvider(String providerCode, String terminalCode)
        {

            //try to get provider from db
            Provider provider = providerService.getByCode(providerCode);

            //return true if provider found with matching terminal code.
            return provider != null && provider
                .TerminalCode
                .Equals(terminalCode);
        }


        [WebMethod]
        public VerifyMemberResult verifyMember(String memberCode)
        {

            Member member = memberService.getByCode(memberCode);

            if (member == null)
                return VerifyMemberResult.InvalidMember;

            if (member.Status == MemberStatus.Suspended)
                return VerifyMemberResult.Suspended;

            if (member.Status == MemberStatus.Active)
                return VerifyMemberResult.Validated;

            return VerifyMemberResult.InvalidMember;

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<ServiceViewModel> getServices()
        {

            List<Service> services = serviceService.getAllServices();
            return ServiceViewModel.fromServiceList(services);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public ServiceViewModel getService(string code)
        {

            return ServiceViewModel.fromService(serviceService.getServiceByCode(code));
        }

        [WebMethod]
        public RecordClaimResult recordClaim(string providerNumber, string memberNumber, string serviceCode, string comments, DateTime dateServiceProvided)
        {
            String result = claimService.addClaim(providerNumber, memberNumber, serviceCode, comments, dateServiceProvided);

            if (!String.IsNullOrWhiteSpace(result))
            {
                return new RecordClaimResult()
                {
                    success = false,
                    message = result
                };
            }

            ServiceViewModel serviceViewModel = ServiceViewModel.fromService(serviceService.getServiceByCode(serviceCode));

            return new RecordClaimResult()
            {
                success = true,
                service = serviceViewModel
            };
        }

        [WebMethod]
        public String recordClaimCheck(string providerNumber, DateTime currentDate, DateTime serviceDate, String memberName, String memberNumber, String serviceCode, decimal fee)
        {
            return claimService.addClaimCheck(providerNumber, currentDate, serviceDate, memberName, memberNumber, serviceCode, fee);
        }

        [WebMethod]
        public String requestProviderDirectory(string providerNumber)
        {
            return serviceService.sendServiceDirectory(providerNumber);
        }
    }
}
