using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SingleNumber
    {

        //public static void Main()
        //{
        //    Console.WriteLine(SingleNumber2(new int[] { 4, 1, 2, 1, 2 }));
        //}

        // My
        public static int SingleNumberSol(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var cur = nums[i];

                if (hashSet.Contains(cur))
                    hashSet.Remove(cur);
                else
                    hashSet.Add(cur);
            }

            return hashSet.First();
        }

        // Like mine solution but through the sum. Speed is almost the same
        public static int SingleNumber1(int[] nums)
        {
            int sumOfSet = 0, sumOfNums = 0;
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var cur = nums[i];

                if (!hashSet.Contains(cur))
                {
                    hashSet.Add(cur);
                    sumOfSet += cur;
                }

                sumOfNums += cur;
            }

            return 2 * sumOfSet - sumOfNums;
        }


        // beautiful via XOR // (the result is 0 if both operands are equal; in all other cases, the result is 1)

        //If we take XOR of zero and some bit, it will return that bit
        //a XOR 0 = a
        //If we take XOR of two same bits, it will return 0
        //a XOR a = 0
        //a XOR b XOR a = (a XOR a) XOR b = 0 XOR b = b

        public static int SingleNumber2(int[] nums)
        {
            int a = 0;

            for (int i = 0; i < nums.Length; i++)
                a ^= nums[i];

            return a;
        }

    }
}
