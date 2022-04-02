using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/binary-tree-inorder-traversal/
    /// </summary>
    internal class BinaryTreeInorderTraversal
    {
        //public static void Main()
        //{
        //    var lastTreeNode = new TreeNode
        //    {
        //        val = 3
        //    };

        //    var secTreeNode = new TreeNode
        //    {
        //        val = 2,
        //        right = null,
        //        left = lastTreeNode
        //    };

        //    var rootTreeNode = new TreeNode
        //    {
        //        val = 1,
        //        left = null,
        //        right = secTreeNode
        //    };

        //    foreach (var item in InorderTraversalStack(rootTreeNode))
        //    {
        //        Console.WriteLine(item);
        //    }
             
        //}

        public static IList<int> InorderTraversal(TreeNode root)
        {
            var res = new List<int>();
            if (root == null)
                return res;


                res.AddRange(InorderTraversal(root.left));

            res.Add(root.val);


                res.AddRange(InorderTraversal(root.right));

            return res;
        }

        public static IList<int> InorderTraversalStack(TreeNode root)
        {
            var result = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count != 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }

                cur = stack.Pop();
                result.Add(cur.val);
                cur = cur.right;
            }

            return result;
        }

        //TODO: Morris Traversal
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