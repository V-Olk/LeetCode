using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium
{
    internal class AddTwoNumbers
    {

        //public static void Main()
        //{
        //    var l3 = new ListNode(3);
        //    var l2 = new ListNode(4, l3); 
        //    var l1 = new ListNode(2, l2); 
            
        //    var l6 = new ListNode(4); 
        //    var l5 = new ListNode(6, l6); 
        //    var l4 = new ListNode(5, l5);

        //    var answ = AddTwoNumbersSol(l1, l4);

        //    while (answ != null)
        //    {
        //        Console.WriteLine(answ.val);
        //        answ = answ.next;
        //    }
        //}

        private static ListNode AddTwoNumbersSol(ListNode l1, ListNode l2)
        {
            ListNode current = null;
            ListNode first = null;
            int over = 0;
            while (l1 != null || l2 != null)
            {
                ListNode prev = current;
                current = new ListNode();

                if (prev == null)
                    first = current;
                else
                    prev.next = current;

                int nodeVal = (l1?.val ?? 0) + (l2?.val ?? 0) + over;

                current.val = nodeVal % 10;

                over = nodeVal / 10;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (over > 0)
                current.next = new ListNode(over);

            return first;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
