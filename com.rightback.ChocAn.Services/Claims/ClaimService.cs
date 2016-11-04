using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Claims
{
    public class ClaimService : BaseService, IClaimService
    {
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
                result = "An error occurred";
            }

            return result; ;
        }
    }
}
