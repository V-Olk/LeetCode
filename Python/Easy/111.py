from collections import deque
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class LvlTreeNode:
    def __init__(self, node, lvl):
        self.node = node
        self.lvl = lvl

    def __str__(self):
        return str(self.node.val) + " " + str(self.lvl)

class Solution:
    def minDepth(self, root: Optional[TreeNode]) -> int:

        if not root:
            return 0

        queue = deque()
        queue.append(LvlTreeNode(root, 1))

        while queue:
            lvl_node = queue.popleft()
            # print(lvl_node)

            if not lvl_node.node.left and not lvl_node.node.right:
                return lvl_node.lvl

            if lvl_node.node.left:
                queue.append(LvlTreeNode(lvl_node.node.left, lvl_node.lvl + 1))

            if lvl_node.node.right:
                queue.append(LvlTreeNode(lvl_node.node.right, lvl_node.lvl + 1))

r3 = TreeNode(4)
r4 = TreeNode(5)

r1 = TreeNode(2, r3, r4)
r2 = TreeNode(3)

r = TreeNode(1, r1, r2)

s = Solution()
print(s.minDepth(r))
