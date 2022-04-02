using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RemoveDuplicatesFromSortedList
    {
        //public static void Main()
        //{
        //    ListNode node5 = new ListNode(4);
        //    ListNode node4 = new ListNode(3, node5);
        //    ListNode node3 = new ListNode(3, node4);
        //    ListNode node2 = new ListNode(2, node3);
        //    ListNode node1 = new ListNode(1, node2);
        //    ListNode head = new ListNode(1, node1);

        //    var newHead = DeleteDuplicates(head);
        //    Console.WriteLine(newHead.val);

        //    while (newHead.next != null)
        //    {
        //        newHead = newHead.next;
        //        Console.WriteLine(newHead.val);
        //    }

        //}

        /// <summary>
        /// Мое// я ищу сразу нужный некст узел и на него уже указываю, остальные же перезаписывают через один
        /// </summary>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;

            ListNode curNode = head, nextNode = head;

            while (nextNode.next != null)
            {
                nextNode = nextNode.next;
                if (nextNode.val != curNode.val)
                {
                    curNode.next = nextNode;
                    curNode = nextNode;
                }
            }
            
            curNode.next = null;

            return head;
        }

        //чье-то
        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null || head.next == null)
                    return head;

            ListNode cur = head;
            while (cur.next != null)
            {
                if (cur.val == cur.next.val)
                    cur.next = cur.next.next;
                else
                    cur = cur.next;
            }

            return head;
        }

        public class ListNode
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
