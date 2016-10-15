using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rightback.ChocAn.DAL;

namespace com.rightback.ChocAn.Services.Members
{
    public class MemberService : BaseService, IMemberService
    {
        public Member getByCode(string code)
        {
            return db.Members
                .Where(m => m.Email.Equals(code))
                .FirstOrDefault();
        }
    }
}
