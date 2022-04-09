using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    internal class LongestSubstringWithoutRepeatingCharacters
    {
        //public static void Main()
        //{
        //    Console.WriteLine(LengthOfLongestSubstringSol("pwwkew"));
        //}

        public static int LengthOfLongestSubstringSol(string s)
        {
            var substringChars = new HashSet<char>();

            int longestSubstring = 0;
            int currentStart = 0;

            while (longestSubstring < s.Length - currentStart)
            {
                substringChars.Clear();

                for (int i = currentStart; i < s.Length; i++)
                {
                    char currentChar = s[i];

                    if (substringChars.Contains(currentChar))
                        break;

                    substringChars.Add(currentChar);
                }

                if (substringChars.Count > longestSubstring)
                    longestSubstring = substringChars.Count;

                currentStart++;
            }

            return longestSubstring;
        }

        public int LengthOfLongestSubstringSol2(string s)
        {
            if (s.Length == 0)
                return 0;

            var map = new Dictionary<char, int>();
            int max = 0;

            for (int i = 0, j = 0; i < s.Length; ++i)
            {
                if (map.TryGetValue(s[i], out int si ))
                    j = Math.Max(j, si + 1);

                map[s[i]] = i;

                max = Math.Max(max, i - j + 1);
            }

            return max;
        }
    }
}
