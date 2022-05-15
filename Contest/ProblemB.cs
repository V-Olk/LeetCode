using System;
using System.Collections.Generic;
using System.Linq;

public class ProgramB
{
    public static void Main1()
    {
        int testCaseCount = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            /*Int32.Parse(*/
            Console.ReadLine()/*)*/;

            int[] importances = Console.ReadLine().Split(' ').Select(imp => Int32.Parse(imp)).ToArray();

            Dictionary<int, int> niceValueByImportance = new();

            int curNiceValue = 1;
            var impsCp = importances.Distinct().OrderByDescending(num => num).ToArray();

            int j;
            for (j = 0; j < impsCp.Length - 1; j++)
            {
                int curImp = impsCp[j];
                int nextImp = impsCp[j + 1];

                niceValueByImportance[curImp] = curNiceValue;

                if (curImp == nextImp + 1)
                {
                    niceValueByImportance[nextImp] = curNiceValue;
                    j++;
                }

                curNiceValue++;
            }

            if (j == impsCp.Length - 1)
                niceValueByImportance[impsCp[j]] = curNiceValue;

            Console.WriteLine(String.Join(" ", importances.Select(imp => niceValueByImportance[imp])));
        }
    }
}