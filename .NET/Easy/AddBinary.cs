using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/add-binary/
    /// </summary>
    class AddBinary
    {
        //public static void Main()
        //{
        //    Console.WriteLine(AddBinarySol("11", "11"));
        //}

        /// <summary>
        /// Very fast
        /// </summary>
        public static string AddBinarySol(string a, string b)
        {
            if (a.Length > b.Length)//b must be longest
                return AddBinarySol(b, a);

            StringBuilder sb = new StringBuilder();
            char carry = '0';

            for (int i = 0; i < b.Length; i++)
            {
                char aChar = i < a.Length ? a[a.Length - 1 - i] : '0';
                char bChar = b[b.Length - 1 - i];
                char curr;

                if (aChar != bChar)
                    curr = carry == '1' ? '0' : '1';
                else
                {
                    curr = carry;
                    carry = aChar;//or bChar, no matter// aChar == bChar
                }

                sb.Insert(0, curr);
            }

            if (carry == '1')
                sb.Insert(0, carry);

            return sb.ToString();
        }

        public static string AddBinary2(string a, string b)
        {
            StringBuilder sb = new StringBuilder(); //Google immutability or string vs stringbuilder if you don't know why we use this instead of regular string
            int i = a.Length - 1, j = b.Length - 1, carry = 0; //two pointers starting from the back, just think of adding two regular ints from you add from back
            while (i >= 0 || j >= 0)
            {
                int sum = carry; //if there is a carry from the last addition, add it to carry 
                if (j >= 0)
                    sum += b[j--] - '0'; //we subtract '0' to get the int value of the char from the ascii

                if (i >= 0)
                    sum += a[i--] - '0';

                sb.Insert(0, sum % 2); //if sum==2 or sum==0 append 0 cause 1+1=0 in this case as this is base 2 (just like 1+9 is 0 if adding ints in columns)
                carry = sum / 2; //if sum==2 we have a carry, else no carry 1/2 rounds down to 0 in integer arithematic
            }

            if (carry != 0)
                sb.Insert(0, carry); //leftover carry, add it

            return sb.ToString();
        }

        public void Swap(ref string p, ref string q) => (p, q) = (q, p);
    }
}
