using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
    /// </summary>
    internal class ConvertSortedArrayToBinarySearchTree
    {
        private TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0)
                return null;

            return GetTreeHead(nums, 0, nums.Length - 1);
        }

        private TreeNode GetTreeHead(int[] nums, int leftBorder, int rightBorder)
        {
            if (leftBorder > rightBorder)
                return null;

            int mid = (leftBorder + rightBorder) / 2;

            return new TreeNode(nums[mid])
            {
                left = GetTreeHead(nums, leftBorder, mid - 1),
                right = GetTreeHead(nums, mid + 1, rightBorder)
            };

        }


        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
