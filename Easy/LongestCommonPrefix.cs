using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    
    class LongestCommonPrefix
    {
        //public static void Main()
        //{
        //    //LongestCommonPrefix1(new string[] { "flower", "flow", "flight" });
        //    Console.WriteLine(LongestCommonPrefix1(new string[] { "ab", "a" }));
        //}

        /// <summary>
        /// The fastest one
        /// </summary>
        public static string LongestCommonPrefixSol(string[] strs)
        {
            // First we find the shortest word
            if (strs.Length == 0)
                return string.Empty;

            string minValue = strs[0];
            foreach (string str in strs)
                if (str.Length < minValue.Length)
                    minValue = str;

            if (minValue.Length == 0)
                return string.Empty;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < minValue.Length; i++)
            {
                var curChar = minValue[i];
                for (int j = 0; j < strs.Length; j++)
                {
                    var curStrChar = strs[j][i];
                    if (curStrChar != curChar)
                        return result.ToString();
                }
                result.Append(curChar);
            }
            return result.ToString();
        }

        /// Average, 100 ms, 25,4 MB
        public static string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0)
                return string.Empty;

            // Then the shortest word will be the first
            Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));
            string minValue = strs[0];

            if (minValue.Length == 0)
                return string.Empty;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < minValue.Length; i++)
            {
                var curChar = minValue[i];
                for (int j = 0; j < strs.Length; j++)
                {
                    var curStrChar = strs[j][i];
                    if (curStrChar != curChar)
                        return result.ToString();
                }
                result.Append(curChar);
            }
            return result.ToString();
        }

        /// My similar solution, but without finding the shortest word
        public static string LongestCommonPrefix1(string[] strs)
        {
            var first = strs[0];

            if (strs.Length == 0)
                return string.Empty;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < first.Length; i++)
            {
                var curChar = first[i];
                for (int j = 0; j < strs.Length; j++)
                {
                    var curStr = strs[j];
                    if (curStr.Length == i)
                        return result.ToString();

                    var curStrChar = curStr[i];
                    if (curStrChar != curChar)
                        return result.ToString();
                }
                result.Append(curChar);
            }
            return result.ToString();
        }
    }
}
