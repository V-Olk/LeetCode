class Solution:
    def convert(self, s: str, numRows: int) -> str:

        if numRows == 1:
            return s

        if numRows == len(s):
            return s

        lists = [""] * numRows

        i = 0
        forward = False

        for char in s:
            lists[i] += char

            if i == 0 or i == numRows - 1:
                forward = not forward

            if forward:
                i += 1
            else:
                i -= 1

            return "".join(lists)

    def convert2(self, s: str, numRows: int) -> str:

        if numRows == 1:
            return s

        result = []
        s_len = len(s)

        section_size = 2 * (numRows - 1)

        for cur_row in range(numRows):
            i = cur_row

            while i < s_len:
                result.append(s[i])

                if cur_row != 0 and cur_row != numRows - 1:
                    sub_section_size = section_size - 2 * cur_row

                    j = i + sub_section_size

                    if j < s_len:
                        result.append(s[j])

                i += section_size

        return "".join(result)