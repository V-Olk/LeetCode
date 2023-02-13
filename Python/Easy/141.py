# Definition for singly-linked list.
class ListNode:
 def __init__(self, x):
     self.val = x
     self.next = None

class Solution:
    def hasCycle(self, head: [ListNode]) -> bool:

        if head is None:
            return False

        slow_node = head
        fast_node = head.next

        while fast_node and fast_node.next:

            if slow_node is fast_node:
                return True

            slow_node = slow_node.next
            fast_node = fast_node.next.next

        return False


