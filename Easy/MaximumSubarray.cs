using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MaximumSubarray
    {
        //public static void Main()
        //{
        //    Console.WriteLine(MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        //}

        public static int MaxSubArray(int[] A)
        {
            // The dp array stores the sum elements for the 1st iteration.If the amount goes to -, then we do not add the previous element dp(the previous amount),
            // and we write down the current current. (because if we have at least one positive element or all negative ones, one will be better than their sum)
            // if there are 5, then just 5 will be better than -2 + -1 + 5.or in the case of - 1, -2, -3.just - 1 would be better than them amounts
            // therefore, each iteration we write the maximum value of the sum in this iteration to the variable
            int n = A.Length;
            int[] dp = new int[n];//dp[i] means the maximum subarray ending with A[i];
            dp[0] = A[0];
            int max = dp[0];

            for (int i = 1; i < n; i++)
            {
                dp[i] = A[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
                max = Math.Max(max, dp[i]);
            }

            return max;
        }

        /// More understandable
        public static int MaxSubArray1(int[] nums)
        {
            // a ---- b ---- c ---- d, find [b, c] has max sum
            // sum([b, c]) = sum([a, c]) - sum([a, b]);
            // so within [a, c], we find the b point that has min value of sum([a, b])
            int max = Int32.MinValue;
            int minSum = 0;
            int runningSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];
                max = Math.Max(max, runningSum - minSum);
                minSum = Math.Min(minSum, runningSum);
            }
            return max;
        }
    }
}
