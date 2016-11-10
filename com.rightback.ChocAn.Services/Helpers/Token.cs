using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services
{
    public class Token
    {

        private static readonly Object obj = new Object();
        private static readonly Random random = new Random();
        public static string CreateShortUniqueString()
        {
            string strDate = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            string randomString;
            lock (obj)
            {
                randomString = RandomString(3);
            }
            return strDate + randomString; // 16 charater
        }
        private static string RandomString(int length)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxy";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
