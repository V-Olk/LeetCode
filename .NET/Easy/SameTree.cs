using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode1
{
    internal class SameTree
    {

        //public static void Main()
        //{
        //    var lastTreeNode = new TreeNode
        //    {
        //        val = 3
        //    };

        //    var secTreeNode = new TreeNode
        //    {
        //        val = -5,
        //        right = null,
        //        left = null
        //    };

        //    var rootTreeNode = new TreeNode
        //    {
        //        val = 0,
        //        left = secTreeNode,
        //        right = lastTreeNode
        //    };


        //    Console.WriteLine(IsSameTree1(rootTreeNode, rootTreeNode));


        //}

        /// <summary>
        /// Recursive
        /// </summary>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null || q == null)
                return false;

            if (p.val != q.val)
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        /// <summary>
        /// With Stack
        /// </summary>
        /// <param name="pp"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static bool IsSameTree1(TreeNode pp, TreeNode qq)
        {
            var stack = new Stack<(TreeNode p, TreeNode q)>();
            stack.Push((pp, qq));

            while (stack.Any())
            {
                var (p, q) = stack.Pop();

                if (p == null && q == null)
                    continue;

                if (!IsValEquals(p, q))
                    return false;

                stack.Push((p.left, q.left));
                stack.Push((p.right, q.right));
            }

            return true;
        }

        private static bool IsValEquals(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return false;

            return p.val == q.val;
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
