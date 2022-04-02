using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LengthOfLastWord
    {
        //public static void Main()
        //{
        //    Console.WriteLine(LengthOfLastWord("HelloWorld"));
        //}

        public static int LengthOfLastWordSol(string s)
        {
            int counter = 0;
            s = s.TrimEnd();
            for (int i = s.Length-1; i >= 0; i--)
            {
                if (s[i] != ' ')
                    counter++;
                else
                    break;
            }
            return counter;
        }
    }
}
