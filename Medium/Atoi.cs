using System;
using System.Collections.Generic;

namespace LeetCode.Medium
{
    internal class Atoi
    {
        public int MyAtoiSol(string s)
        {
            int startIndex = 0;

            while (startIndex < s.Length && s[startIndex] == ' ')
            {
                startIndex++;
            }

            var intAsChars = new List<char>(s.Length - startIndex);
            int maxLength = 10;

            bool skipZeros = true;

            for (int i = startIndex; i < s.Length; i++)
            {
                char curChar = s[i];

                if (skipZeros && curChar == '0')
                    continue;

                skipZeros = false;

                if (i == maxLength)
                {
                    if (s[i] > 47 && s[i] < 58)
                    {
                        return (maxLength == 10 || s[startIndex] == '+') ? Int32.MaxValue : Int32.MinValue;
                    }

                    break;
                }

                if (i == startIndex && (curChar == 43 || curChar == 45))
                {
                    skipZeros = true;

                    maxLength = 11;

                    intAsChars.Add(curChar);
                    continue;
                }

                if (curChar > 47 && curChar < 58)
                {
                    intAsChars.Add(curChar);
                    continue;
                }

                break;
            }

            if (intAsChars.Count == 0
                || (intAsChars.Count == 1 && (intAsChars[0] == 43 || intAsChars[0] == 45)))
                return 0;

            var result = new string(intAsChars.ToArray());

            var converResult = Int32.TryParse(result, out int intResult);

            if (converResult)
                return intResult;

            return (maxLength == 10 || s[startIndex] == '+') ? Int32.MaxValue : Int32.MinValue;
        }
    }
}
