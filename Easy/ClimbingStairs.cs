using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ClimbingStairs
    {
        //public static void Main()
        //{
        //    var stp = new Stopwatch();
        //    stp.Start();
        //    Console.WriteLine(ClimbStairs1(45));
        //    stp.Stop();
        //    Console.WriteLine(stp.Elapsed);
        //}

        #region Too slow

        public static int ClimbStairs(int n)
        {
            Count(n);

            return Ways;
        }

        private static void Count(int n)
        {
            if (n == 1)
            {
                return;
            }
            else if (n == 2)
            {
                Ways += 1;
                return;
            }
            else
            {
                Ways += 1;

                Count(n - 1);
                Count(n - 2);
            }
        }

        public static int Ways { get; set; } = 1;

        #endregion

        #region memoization
        public static int ClimbStairs1(int n)
        {
            int[] memo = new int[n + 1];
            return climb_Stairs(0, n, memo);
        }
        public static int climb_Stairs(int i, int n, int[] memo)
        {
            if (i > n)
                return 0;

            if (i == n)
                return 1;

            if (memo[i] > 0)
                return memo[i];

            memo[i] = climb_Stairs(i + 1, n, memo) + climb_Stairs(i + 2, n, memo);
            Console.WriteLine(i + " " + memo[i]);
            return memo[i];
        }

        #endregion

        #region Fibonacci 

        public int ClimbStairs2(int n)
        {
            if (n == 1)
                return 1;

            int first = 1;
            int second = 2;
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }

            return second;
        }

        #endregion
    }
}
