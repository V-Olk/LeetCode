using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SearchInsertPosition
    {
        //public static void Main()
        //{
        //    Console.WriteLine();
        //}

        public static int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (target <= nums[i])
                    return i;
            }
            return nums.Length;
        }

    }
}
