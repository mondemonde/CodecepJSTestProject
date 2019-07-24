using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTextFilterClassLibrary
{
   public static class Helper
    {
        public static string GetNumbersOnly(string input)
        {
            string output = string.Empty;
            foreach(char c in input)
            {
                if(char.IsNumber(c) || c=='.' )
                     output += c;
            }
            return output;
        }

        public static string GetValidFileName(string illegal)
        {
            //string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            invalid += "=";
            foreach (char c in invalid)
            {
                illegal = illegal.Replace(c.ToString(), "");
            }

            return illegal;
        }

        /// <summary>
        /// method to convert a series of string to proper case 
        /// </summary>
        /// <param name="str">value we want converted</param>
        /// <returns></returns>
        public static string FormatProperCase(string str)
        {
            // if not value is provided throw an exception
            if (string.IsNullOrEmpty(str)) return string.Empty;
            //if the stirng is less than 2 characters return it upper case
            if (str.Length < 2) return str.ToUpper();
            string[] strlst = str.Split(new char[] { ' ' });
            foreach (string s in strlst)
            {
                int i = 0;
                string sout = string.Empty;
                foreach (char c in s)
                {
                    sout += (i == 0 ? Char.ToUpper(c) : Char.ToLower(c));
                    i++;
                }
                str = str.Replace(s, sout);
            }
            return str;
        }
    }
}
