using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// </summary>
    internal class MaximumDepthOfBinaryTree
    {
        private int MaxDepth(TreeNode root)
        {
            return root == null ? 0 : 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
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
