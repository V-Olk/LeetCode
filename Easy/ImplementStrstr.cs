using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ImplementStrstr
    {
        //public static void Main()
        //{
        //    Console.WriteLine(StrStr("mississippi", "issi"));
        //}

        public static int StrStr(string haystack, string needle)
        {
            //if (needle == string.Empty) и needle.Length == 0//это медленнее чем IsNullOrEmpty
            if (string.IsNullOrEmpty(needle))
                return 0;

            if (string.IsNullOrEmpty(haystack))
                return -1;

            int j = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[j])
                {
                    j++;

                    if (j == needle.Length)
                        return i - j + 1;
                }
                else
                {
                    i = i - j;
                    j = 0;
                }
            }

            return -1;

            //return RegexIndexOf(haystack, needle);

            //return haystack.IndexOf(needle);
        }

        /// <summary>
        /// Too slow
        /// </summary>
        public int RegexIndexOf(string str, string pattern)
        {
            var m = System.Text.RegularExpressions.Regex.Match(str, pattern);
            return m.Success ? m.Index : -1;
        }
    }
}
