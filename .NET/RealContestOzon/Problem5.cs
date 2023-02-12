using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

public class Program12312311
{
    public static void Main123123()
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            Console.ReadLine();

            string[] nm = Console.ReadLine().Split(' ');

            int lines = int.Parse(nm[0]);
            int columns = int.Parse(nm[1]);

            List<int[]> matrix = new();

            for (int j = 0; j < lines; j++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(val => int.Parse(val)).ToArray();

                matrix.Add(row);
            }

            int clicksCount = int.Parse(Console.ReadLine());

            int[] clicks = Console.ReadLine().Split(' ').Select(val => int.Parse(val) - 1).ToArray();

            SortedDictionary<int, List<int[]>> ordDict;

            int lasColumnClicked = -1;
            for (int j = 0; j < clicks.Length; j++)
            {
                int columnClicked = clicks[j];

                if (columnClicked == lasColumnClicked)
                    continue;

                lasColumnClicked = columnClicked;

                ordDict = new();

                for (int k = 0; k < matrix.Count; k++)
                {
                    var matrixLine = matrix[k];

                    int columnVal = matrixLine[columnClicked];

                    if (ordDict.TryGetValue(columnVal, out var lst))
                    {
                        lst.Add(matrixLine);
                    }
                    else
                    {
                        ordDict[columnVal] = new List<int[]>() { matrixLine };
                    }
                }

                matrix = GetMatrixFromDict(ordDict);
            }

            for (int k = 0; k < matrix.Count; k++)
            {
                Console.WriteLine(String.Join(" ", matrix[k]));
            }

            Console.WriteLine();
        }
    }

    private static List<int[]> GetMatrixFromDict(SortedDictionary<int, List<int[]>> ordDict)
    {
        var reslst = new List<int[]>();

        foreach (var list in ordDict.Values)
        {
            foreach (var VARIABLE in list)
            {
                reslst.Add(VARIABLE);
            }
        }

        return reslst;
    }
}