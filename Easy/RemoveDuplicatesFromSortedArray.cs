using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RemoveDuplicatesFromSortedArray
    {
        //public static void Main()
        //{
        //    RemoveDuplicates(new int[] { 0, 0, 0, 2 });
        //}

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public static int RemoveDuplicates1(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    count++;
                else
                    nums[i - count] = nums[i];
            }
            return nums.Length - count;
        }
    }
}
