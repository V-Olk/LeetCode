using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium
{
    class IntegerToRoman
    {
        //public static void Main()
        //{
        //    IntToRoman2(58);
        //}

        public static readonly Dictionary<string, int> IntByRomanStr = new Dictionary<string, int>()
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D",  500 },
            { "CD", 400 },
            { "C",  100 },
            { "XC",  90 },
            { "L",   50 },
            { "XL",  40 },
            { "X",   10 },
            { "IX",   9 },
            { "V",    5 },
            { "IV",   4 },
            { "I",    1 }
        };

        public static string IntToRoman(int num)
        {
            string result = string.Empty;

            foreach (var roman in IntByRomanStr)
            {
                while (roman.Value <= num)
                {
                    result += roman.Key;
                    num -= roman.Value;
                }
            }

            return result;
        }

        /// same but with stringBuilder
        public static string IntToRoman1(int num)
        {
            StringBuilder result = new StringBuilder();

            foreach (var roman in IntByRomanStr)
            {
                while (roman.Value <= num)
                {
                    result.Append(roman.Key);
                    num -= roman.Value;
                }
            }

            return result.ToString();
        }

        public static readonly string[] s = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        public static readonly int[] v = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        /// recursive solution
        public static string IntToRoman2(int num)
        {
            if (num <= 0)
                return string.Empty;

            int i = s.Length - 1;
            for (; i >= 0; i--)
                if (num >= v[i])
                    break;
            return s[i] + IntToRoman2(num - v[i]);
        }
    }
}
