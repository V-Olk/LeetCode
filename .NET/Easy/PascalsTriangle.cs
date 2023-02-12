using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PascalsTriangle
    {

        //public static void Main()
        //{
        //    foreach (IList<int> lst in Generate(5))
        //    {
        //        foreach (var item in lst)
        //        {
        //            Console.Write(item + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //}

        public static IList<IList<int>> Generate(int numRows)
        {
            int[][] result = new int[numRows][];
            //result[0] = new int[] { 1 };

            for (int i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];

                result[i][0] = result[i][i] = 1;

                for (int j = 1; j < i / 2 + 1; j++)
                    result[i][j] = result[i][i - j] = result[i - 1][j - 1] + result[i - 1][j];
            }

            return result;
        }

    }
}
