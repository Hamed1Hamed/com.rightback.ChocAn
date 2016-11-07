using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Extensions
{
    public static class PersonCoverStatmentExtensions
    {
        /// <summary>
        /// Generate basic info about provider like name and address with some info about claims processed
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public static string generateProviderCoverStatment(this Provider provider, IQueryable<Claim> claims)
        {
            string newLine = "<br/>";
            string statementCover = provider.Name + newLine + provider.Code + newLine + provider.StreetAddres + newLine
            + provider.City + newLine + provider.State + newLine + provider.Zip + newLine + "number of consultations:"
            + claims.Where(c => c.Provider.ProviderID == provider.ProviderID).Count() + newLine
            + "total fee: " + claims.Where(c => c.Provider.ProviderID == provider.ProviderID).Sum(e => e.Fee) + newLine;
            return statementCover;
        }
        /// <summary>
        /// return member info in HTML 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string generateMemberCoverStatment(this Member member)
        {
            string newLine = "<br/>";
            string statementCover = member.Name + newLine + member.Code + newLine + member.StreetAddres
                + newLine + member.City + newLine + member.State + newLine + member.Zip + newLine;
            return statementCover;
        }
    }
}
