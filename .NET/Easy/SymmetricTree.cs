using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    internal class SymmetricTree
    {

        /// <summary>
        /// Recursive
        /// </summary>
        public bool IsSymmetric(TreeNode root)
        {
            return root == null || IsNodesSymmetric(root.left, root.right);
        }

        private bool IsNodesSymmetric(TreeNode leftNode, TreeNode rightNode)
        {
            if (leftNode == null && rightNode == null)
                return true;

            if (leftNode == null || rightNode == null || leftNode.val != rightNode.val)
                return false;

            return IsNodesSymmetric(leftNode.left, rightNode.right) && IsNodesSymmetric(leftNode.right, rightNode.left);
        }

        /// <summary>
        /// Stack
        /// </summary>
        public bool IsSymmetricStack(TreeNode root)
        {
            if (root == null)
                return true;

            var stack = new Stack<TreeNode>();
            stack.Push(root.left);
            stack.Push(root.right);

            while (stack.Any())
            {
                TreeNode n1 = stack.Pop(), n2 = stack.Pop();
                if (n1 == null && n2 == null)
                    continue;

                if (n1 == null || n2 == null || n1.val != n2.val)
                    return false;

                stack.Push(n1.left);
                stack.Push(n2.right);
                stack.Push(n1.right);
                stack.Push(n2.left);
            }

            return true;
        }
    }

    public class TreeNode
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
