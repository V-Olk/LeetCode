from typing import List


class Solution:
    def getRow(self, rowIndex: int) -> List[int]:
        res = []

        for i in range(rowIndex // 2 + 1):
            res.append(self.get_num(rowIndex, i))

        return res + res[::-1][1:] if rowIndex % 2 == 0 else res + res[::-1]

    def calc_numerator(self, row, pos) -> int:
        return 1 if pos == 0 else row * self.calc_numerator(row - 1, pos - 1)

    def calc_denumerator(self, pos) -> int:
        return 1 if pos == 0 else pos * self.calc_denumerator(pos - 1)

    def get_num(self, row, pos) -> int:
        return 1 if pos == 0 else self.calc_numerator(row, pos) // self.calc_denumerator(pos)

    def getRow2(self, r):
        hr = r // 2
        res = [1]

        up = r
        down = 1

        for i in range(hr):
            res.append(res[i] * up // down)
            up = up - 1
            down = down + 1

        return res + res[::-1][1:] if r % 2 == 0 else res + res[::-1]


s = Solution()
print(s.getRow2(9))

# 0  1  2       3
# 1  n  n(n-1)  n(n-1)(n-2)      n == rowIndex
# ---------------------------------------
# 0! 1! 2!      3!
