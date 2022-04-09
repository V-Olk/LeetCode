using System;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/longest-palindromic-substring/
    /// </summary>
    internal class LongestPalindromicSubstring
    {
        //public static void Main()
        //{
        //    Console.WriteLine(LongestPalindromeSol("aboba"));
        //}

        public static string LongestPalindromeSol(string s)
        {
            if (String.IsNullOrEmpty(s))
                return String.Empty;

            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                
                int len = Math.Max(len1, len2);

                if (len <= end - start + 1)
                    continue;

                start = i - (len - 1) / 2;
                end = i + len / 2;
            }

            return s.Substring(start, (end - start) + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            int l = left, r = right;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return r - l - 1;
        }
    }
}
