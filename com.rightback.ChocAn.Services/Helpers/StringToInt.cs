using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services
{
    class StringToInt
    {
            public static bool isNumber(string text)
            {
                try
                {
                    int m = Int32.Parse(text);
                    return true;
                }
                catch (FormatException e)
                {

                    return false;
                }
            }

            public static int textToNumber(string text)
            {
                try
                {
                    int m = Int32.Parse(text);
                    return m;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    return -1;
                }
            }
        }
    }
