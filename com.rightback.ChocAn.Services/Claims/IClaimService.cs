
using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Claims
{
    public interface IClaimService
    {
        /// <summary>
        /// used to add new claim
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <param name="memberNumber"></param>
        /// <param name="serviceCode"></param>
        /// <param name="comments"></param>
        /// <param name="dateServiceProvided"></param>
        /// <returns>String</returns>
        String addClaim(string providerNumber, string memberNumber, string serviceCode, string comments, DateTime dateServiceProvided);

        /// <summary>
        /// used by provider to check claims
        /// </summary>
        /// <param name="providerNumber"></param>
        /// <param name="currentDate"></param>
        /// <param name="serviceDate"></param>
        /// <param name="memberName"></param>
        /// <param name="memberNumber"></param>
        /// <param name="serviceCode"></param>
        /// <param name="fee"></param>
        /// <returns>String</returns>
        String addClaimCheck(string providerNumber, DateTime currentDate, DateTime serviceDate, String memberName, String memberNumber, String serviceCode, decimal fee);
        /// <summary>
        /// get claims within duration
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>IQueryable</returns>
        IQueryable<Claim> getClaimsWithin(DateTime start, DateTime end);

        /// <summary>
        /// get confirmed claims that provider have already checked within duration
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>IQueryable</returns>
        IQueryable<ClaimCheck> getCheckedClaimsWithin(DateTime start, DateTime end);


        /// <summary>
        /// convert claims into list serialized claims 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="claims"></param>
        /// <returns>list</returns>
        IList<ReportItemForProvider> generateSerializedReport(Provider person, IQueryable<Claim> claims);

        /// <summary>
        /// convert checked claims into list serialized claims 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="claims"></param>
        /// <returns>list</returns>
        IList<ReportItemForProvider> generateSerializedReport(Provider person, IQueryable<ClaimCheck> claims);

        /// <summary>
        /// convert claims into list serialized claims 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="claims"></param>
        /// <returns>list</returns>
        IList<ReportItemForMember> generateSerializedReport(Member member, IQueryable<Claim> claims);
    }
}
