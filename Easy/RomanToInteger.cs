using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/roman-to-integer/
    /// </summary>
    class RomanToInteger
    {
        //public static void Main()
        //{
        //    RomanToInt1("IV");
        //}

        public static readonly Dictionary<char, int> IntByRomanChar = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000}
        };

        /// <summary>
        /// Someone 's
        /// </summary>
        public static int RomanToInt1(string s)
        {
            var result = 0;
            var last = 0;

            foreach (char curChar in s)
            {
                var current = IntByRomanChar[curChar];

                if (current > last)
                {
                    result -= last * 2;
                }

                result += current;
                last = current;
            }

            return result;
        }

        /// <summary>
        /// Not finished
        /// </summary>
        public static int RomanToInt(string s)
        {
            int result = default, j = default;
            for (int i = 0; i < s.Length; i++)
            {
                j++;
                var curChar = s[i];

                var curInt = IntByRomanChar[curChar];

                if (j != s.Length)
                {
                    var nextChar = s[j];

                    if (curChar == nextChar)
                    {
                        int repeatCount = 0;
                        while (curChar == nextChar && j != s.Length)
                        {
                            repeatCount++;
                            //nextChar == s[];
                        }
                    }
                    else
                    {
                        switch (curChar)
                        {
                            case 'I':

                                break;

                            case 'X':

                                break;

                            case 'C':

                                break;

                            default:
                                break;
                        }
                        i++;
                    }
                }
            }

            return result;
        }
    }
}
