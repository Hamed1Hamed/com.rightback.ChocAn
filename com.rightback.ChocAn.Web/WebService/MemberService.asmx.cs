using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Enums;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using static com.rightback.ChocAn.DAL.Member;

namespace com.rightback.ChocAn.Web.WebService
{
    /// <summary>
    /// Member webservice provides methods for accounting provider to suspend and reinstate member statuses.
    /// </summary>
    [WebService(Namespace = "http://rightback.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MemberService : System.Web.Services.WebService
    {
        private IMemberService memberService = ServiceFactory.getMemberService();

        /// <summary>
        /// To be used by Acme Accounting Services to update member information.
        /// </summary>
        /// <param name="memberCode">Code of the member to change its status.</param>
        /// <param name="status">Can be Active or Invalid</param>
        /// <returns></returns>
        [WebMethod]
        public string UpdateMemberStatus(string memberCode, MemberStatus status)
        {
           Member member = memberService.getByCode(memberCode);
           
            if (member == null)
                return "NOK - Member not found.";

            if (status != MemberStatus.Active && status != MemberStatus.Suspended)
                return "NOK - Invalid status";

            member.Status = status;

            memberService.upsertMember(member);

            return "OK";
        }
    }
}
