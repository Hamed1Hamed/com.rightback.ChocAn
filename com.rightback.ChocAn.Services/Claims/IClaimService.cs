
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Claims
{
    public interface IClaimService
    {
        String addClaim(string providerNumber, string memberNumber, string serviceCode, string comments, DateTime dateServiceProvided);

        String addClaimCheck(string providerNumber,DateTime currentDate,DateTime serviceDate,String memberName,String memberNumber,String serviceCode,decimal fee);
    }
}
