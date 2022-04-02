using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ValidParentheses
    {
        //      public static void Main()
        //      {
        //	IsValid("()[]{}");
        //}

        /// Throw into the stack what should meet to close
        public static bool IsValid(string s)
        {
            if (s.Length % 2 == 0)
                return false;

            Stack<char> stack = new Stack<char>();
            //         for (int i = 0; i < s.Length; i++)
            //         {
            //	var c = s[i];
            //	if (c == '(')
            //		stack.Push(')');
            //	else if (c == '{')
            //		stack.Push('}');
            //	else if (c == '[')
            //		stack.Push(']');
            //	else if (stack.Count == 0 || stack.Pop() != c)
            //		return false;
            //}

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                switch (c)
                {
                    case '(':
                        stack.Push(')');
                        break;

                    case '{':
                        stack.Push('}');
                        break;

                    case '[':
                        stack.Push(']');
                        break;

                    default:
                        if (stack.Count == 0 || stack.Pop() != c)
                            return false;
                        break;
                }
                //            if (c == '(')
                //	stack.Push(')');
                //else if (c == '{')
                //	stack.Push('}');
                //else if (c == '[')
                //	stack.Push(']');
                //else if (stack.Count == 0 || stack.Pop() != c)
                //	return false;
            }

            //с foreach медленнее
            //foreach (char c in s)
            //  {
            //	if (c == '(')
            //		stack.Push(')');
            //	else if (c == '{')
            //		stack.Push('}');
            //	else if (c == '[')
            //		stack.Push(']');
            //	else if (stack.Count == 0 || stack.Pop() != c)
            //		return false;
            //}

            return stack.Count == 0;
        }
    }
}
