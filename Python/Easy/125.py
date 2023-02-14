class Solution:
    def get_next_char_index(self, index, s, s_len, backward):

        while True:

            if backward:
                index -= 1
            else:
                index += 1

            if index >= s_len:
                return -1, -1

            cur_char_as_numb = ord(s[index])

            if 64 < cur_char_as_numb < 91:
                cur_char_as_numb += 32
                return index, cur_char_as_numb

            if 96 < cur_char_as_numb < 123 or 47 < cur_char_as_numb < 58:
                return index, cur_char_as_numb

    def isPalindrome(self, s: str) -> bool:

        s_len = len(s)

        left_i = -1
        right_i = s_len

        while True:
            left_i, l_ch_as_int = self.get_next_char_index(left_i, s, s_len, False)

            if left_i == -1:
                return True

            right_i, r_ch_as_int = self.get_next_char_index(right_i, s, s_len, True)

            if right_i == -1:
                return True

            if l_ch_as_int != r_ch_as_int:
                return False

            if left_i >= right_i:
                return True

sol = Solution()
print(str(sol.isPalindrome("A man, a plan, a canal: Panama")))