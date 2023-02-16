from typing import Optional


# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def hasPathSum(self, root: Optional[TreeNode], targetSum: int) -> bool:

        if root is None:
            return False

        cur_sum = targetSum - root.val

        if not root.left and not root.right and cur_sum == 0:
            return True

        return self.hasPathSum(root.left, cur_sum) or self.hasPathSum(root.right, cur_sum)
