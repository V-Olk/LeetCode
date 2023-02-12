using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    class ReverseInteger
    {
        //public static void Main()
        //{
        //    Reverse1(-2147483648);
        //}

        public static int Reverse(int x)
        {
            string xStr = x.ToString();
            if (xStr[0] == '-')
                xStr = $"-{new string(xStr.Substring(1).Reverse().ToArray())}";
            else
                xStr = new string(xStr.Reverse().ToArray());

            var res = Int64.Parse(xStr);
            if (res > Int32.MaxValue || res < Int32.MinValue)
                return 0;
            else
                return ((Int32)res);
        }

        public static int Reverse1(int x)
        {
            try
            {
                int res = Int32.Parse(new string(Math.Abs(x).ToString().Reverse().ToArray()));
                return (x < 0) ? res * -1 : res;
            }
            catch
            {
                return 0;
            }
        }
        
        public static int Reverse2(int x)
        {
            string str = new string(x.ToString().Trim('-').Reverse().ToArray());
            bool tryInt32 = int.TryParse(str, out int intValue);
            return tryInt32 ? x.ToString().Contains("-") ? intValue * -1 : intValue : 0;
        }
    }
}
