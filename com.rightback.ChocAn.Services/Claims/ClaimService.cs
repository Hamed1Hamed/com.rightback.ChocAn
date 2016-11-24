using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Claims
{
    public class ClaimService : BaseService, IClaimService
    { 
        /// <summary>
        /// Adds claim entry to database with the provided details.
        /// </summary>
        /// <param name="providerNumber">9 digit provider number</param>
        /// <param name="memberNumber">9 digit member number</param>
        /// <param name="serviceCode">6 digit service code</param>
        /// <param name="comments">Comments for the provided service (optional)</param>
        /// <param name="dateServiceProvided">Date of the service provided.</param>
        /// <returns>Returns empty string if successfull or explanation about the error otherwise.</returns>
        public string addClaim(string providerNumber, string memberNumber, string serviceCode, string comments, DateTime dateServiceProvided)
        {
                Provider provider = db.Providers.Where(p => p.Code.Equals(providerNumber)).FirstOrDefault();
            if (provider == null)
                return "Provider not found.";

            Member member = db.Members.Where(m => m.Code.Equals(memberNumber)).FirstOrDefault();
            if (member == null)
                return "Member not found.";

            Service service = db.Services.Where(s => s.Code.Equals(serviceCode)).FirstOrDefault();
            if (service == null)
                return "Service not found.";

            Claim newClaim = new Claim()
            {
                Comments = comments,
                DateOfClaim = dateServiceProvided,
                DateOfClaimRecorded = DateTime.Now,
                Member = member,
                Provider = provider,
                Service = service,
                Fee = service.Fee,
                Name = String.Format("Service {0} provided to {1}. (by {2},{3})", service.Name, member.Name, provider.Name, dateServiceProvided)
            };

            db.Claims.Add(newClaim);
            db.SaveChanges();

            return String.Empty;
        }

        /// <summary>
        /// Adds claim check entry to the database
        /// </summary>
        /// <param name="providerCode">9 digit provider code</param>
        /// <param name="currentDate">Date of the request</param>
        /// <param name="serviceDate">Date of the service provided</param>
        /// <param name="memberName">Name of the member who get the service</param>
        /// <param name="memberNumber">9 digit member code</param>
        /// <param name="serviceCode">6 digit service code</param>
        /// <param name="fee">Fee to be recorded for confirmation purposes.</param>
        /// <returns>Empty string if successfull or explanation about the error otherwise.</returns>
        public string addClaimCheck(string providerCode,DateTime currentDate, DateTime serviceDate, string memberName, string memberNumber, string serviceCode, decimal fee)
        {
            String result = String.Empty;

            Provider provider = db.Providers
                .Where(p => p.Code.Equals(providerCode))
                .FirstOrDefault();

            if (provider == null)
            {
                result = "Invalid provider code.";
                return result;
            }

            ClaimCheck claimCheck = new ClaimCheck()
            {
                DateOfClaimCheck = currentDate,
                DateOfServiceProvided = serviceDate,
                MemberName = memberName,
                MemberNumber = memberNumber,
                ServiceCode = serviceCode,
                Fee = fee,
                Provider = provider
            };

            try
            {
                db.ClaimChecks.Add(claimCheck);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                result = "An error occurred, "+ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Returns claim entries between the provided two dates.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IQueryable<Claim> getClaimsWithin(DateTime start, DateTime end)
        {
            return from u in db.Claims.Where(e => e.DateOfClaim > start & e.DateOfClaim < end) select u;
        }

        /// <summary>
        /// get claims that provider have already processed claim check upon within tow dates
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>IQueryable</returns>
        public IQueryable<ClaimCheck> getCheckedClaimsWithin(DateTime start, DateTime end)
        {
            return from u in db.ClaimChecks.Where(
                e => e.DateOfServiceProvided > start & e.DateOfServiceProvided < end).OrderBy(e => e.Timestamp)
                   select u;
        
        }

        /// <summary>
        /// generate list of serialized reoprt item for the provider
        /// </summary>
        /// <param name="person"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public IList<ReportItemForProvider> generateSerializedReport(Provider person,IQueryable<Claim> claims)
        {
            if (claims==null)
            return null;
            IList<ReportItemForProvider> Data = new List<ReportItemForProvider>();
            foreach (Claim c in claims)
                Data.Add(new ReportItemForProvider(c));
            return Data;
        }

        /// <summary>
        ///  generate list of serialized reoprt item for the member
        /// </summary>
        /// <param name="member"></param>
        /// <param name="claims"></param>
        /// <returns> serialized list of claims </returns>
        public IList<ReportItemForMember> generateSerializedReport(Member member, IQueryable<Claim> claims)
        {
            if (claims == null)
                return null;
            IList<ReportItemForMember> Data = new List<ReportItemForMember>();
            foreach (Claim c in claims)
                Data.Add(new ReportItemForMember(c));
            return Data;

        }
        /// <summary>
        ///  generate list of serialized reoprt item for the member
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="claims"></param>
        /// <returns> serialized list of claims </returns>

        public IList<ReportItemForProvider> generateSerializedReport(Provider person, IQueryable<ClaimCheck> claims)
        {
            if (claims == null)
                return null;
            IList<ReportItemForProvider> Data = new List<ReportItemForProvider>();
            foreach (ClaimCheck c in claims)
                Data.Add(new ReportItemForProvider(c));
            return Data;
        }
    }
}
