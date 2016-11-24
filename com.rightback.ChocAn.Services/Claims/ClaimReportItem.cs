using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Claims
{

    /// <summary>
    /// Serializable class for claim class to be used to convert 
    /// service lists to datatable etc-like serializable structures.
    /// </summary>
    public class ReportItemForProvider
    {

        public string Date_of_service { get; set; }
        public string TimeStamp { get; set; }
        public string Member_name { get; set; }
        public string Member_number { get; set; }
        public string Service_code { get; set; }
        public string Fee { get; set; }
        public ReportItemForProvider(Claim claim)
        {
            Date_of_service = claim.DateOfClaim.ToString("yyyy-MM-dd HH:mm tt");
            TimeStamp = claim.DateOfClaimRecorded.ToString();
            Member_name = claim.Member.Name;
            Member_number = claim.Member.Code;
            Service_code = claim.Service.ServiceID.ToString();
            Fee = claim.Fee.ToString();
        }
        public ReportItemForProvider(ClaimCheck claim)
        {
            Date_of_service = claim.DateOfServiceProvided.ToString("yyyy-MM-dd HH:mm tt");
            TimeStamp = claim.DateOfClaimCheck.ToString();
            Member_name = claim.MemberName;
            Member_number = claim.MemberName;
            Service_code = claim.ServiceCode;
            Fee = claim.Fee.ToString();
        }
    }
    /// <summary>
    /// Serializable class for claim class to be used to convert 
    /// service lists to datatable etc-like serializable structures.
    /// </summary>
    public class ReportItemForMember
    {

        public string Date { get; set; }
        public string Provider { get; set; }
        public string Service { get; set; }
        public ReportItemForMember(Claim claim)
        {
            Date = claim.DateOfClaim.ToString("yyyy-MM-dd"); ;
            Provider = claim.Provider.Name;
            Service = claim.Service.Name;
        }
    }

}
