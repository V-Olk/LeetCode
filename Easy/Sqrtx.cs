using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Sqrtx
    {
        //public static void Main()
        //{
        //    Console.WriteLine(MySqrt1(88));
        //}

        public static int MySqrt(int x)
        {
            int left = 1, right = x;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (mid == x / mid)
                    return mid;

                else if (mid < x / mid)
                    left = mid + 1;

                else
                    right = mid - 1;
            }
            return right;
        }

        /// <summary>
        ///  Newton's method
        /// </summary>
        public static int MySqrt1(int x)
        {
            long r = x;
            while (r * r > x)
            {
                r = (r + x / r) / 2;
                Console.WriteLine(r);
            }
            return (int)r;
        }
    }
}
