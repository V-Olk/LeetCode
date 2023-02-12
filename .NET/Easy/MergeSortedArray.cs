using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class MergeSortedArray
    {

        //public static void Main()
        //{
        //    Merge1(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { -2, 5, 6 }, 3);
        //}

        /// short
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            nums2.CopyTo(nums1, m);
            Array.Sort(nums1);
        }

        // Someone's 
        public static void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
            // For the case of negative numbers
            while (j >= 0)
                nums1[k--] = nums2[j--];
        }
    }
}


