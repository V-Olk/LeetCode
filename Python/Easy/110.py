# Definition for a binary tree node.
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
         self.val = val
         self.left = left
         self.right = right

class Solution:
    def dfsHeight(self, curNode) -> int:
        if curNode is None:
            return 0

        leftHeight = self.dfsHeight(curNode.left)

        if leftHeight == -1:
            return -1

        rightHeight = self.dfsHeight(curNode.right)

        if rightHeight == -1:
            return -1

        if abs(leftHeight - rightHeight) > 1:
            return -1

        return max(leftHeight, rightHeight) + 1

    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        return self.dfsHeight(root) != 1


