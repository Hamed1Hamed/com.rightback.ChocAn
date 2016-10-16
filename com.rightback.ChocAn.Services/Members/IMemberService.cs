using com.rightback.ChocAn.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Members
{
    public interface IMemberService
    {
        /// <summary>
        /// Returns member by 9 digit member code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Member getByCode(string code);
    }
}
