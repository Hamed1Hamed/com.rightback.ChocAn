using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Enums;
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
    /// Provides services for the terminal device to invoke to operate.
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
        /// <param name="providerCode">9 digit code of the provider.</param>
        /// <param name="terminalCode">Embedded terminal code from the device.</param>
        /// <returns>True if provider is found, false otherwise.</returns>
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

        /// <summary>
        /// Returns the status of the member for the provided membercode.
        /// </summary>
        /// <param name="memberCode">9 digit code for the provider.</param>
        /// <returns>Can be Invalid, Suspended or Validated</returns>
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

        /// <summary>
        /// Returns all available services (products) in the system which can be given by a provider.
        /// </summary>
        /// <returns>List of service view models.</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<ServiceViewModel> getServices()
        {

            List<Service> services = serviceService.getAllServices();
            return ServiceViewModel.fromServiceList(services);
        }

        /// <summary>
        /// Returns a service object by the provided service code.
        /// </summary>
        /// <param name="code">6 digit code for the service</param>
        /// <returns>Service object or null if no service found.</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public ServiceViewModel getService(string code)
        {
            return ServiceViewModel.fromService(serviceService.getServiceByCode(code));
        }

        /// <summary>
        /// Records a claim data into the database according to the provided details.
        /// </summary>
        /// <param name="providerNumber">9 digit provider number</param>
        /// <param name="memberNumber">9 digit member number</param>
        /// <param name="serviceCode">6 digit service code</param>
        /// <param name="comments">Comments for the provided service. (optional)</param>
        /// <param name="dateServiceProvided">Date of the service provided.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Records a ClaimCheck entry into the database.
        /// </summary>
        /// <param name="providerNumber">9 digit provider number.</param>
        /// <param name="currentDate">Current date as provided by the terminal interface.</param>
        /// <param name="serviceDate">Date of the provided service</param>
        /// <param name="memberName">Name of the member</param>
        /// <param name="memberNumber">9 digit number for the member</param>
        /// <param name="serviceCode">6 digit service code.</param>
        /// <param name="fee">Fee of the service for confirmation purposes.</param>
        /// <returns>Empty string if successfull or information about the error if operation failed.</returns>
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
