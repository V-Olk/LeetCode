using System;
using System.Collections.Generic;
using System.Linq;

public class Program1234234
{

    public static void Main2222()
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {

            var recordCounts = int.Parse(Console.ReadLine());

            var numbersByName = new SortedDictionary<string, List<string>>(); 

            for (int j = 0; j < recordCounts; j++)
            {
                string[] nq = Console.ReadLine().Split(' ');

                string name = nq[0];
                string number = nq[1];

                if (numbersByName.TryGetValue(name, out List<string> numsByName))
                {
                    bool numberAlredyExist = numsByName.Contains(number);
                    if (numberAlredyExist)
                    {
                        numsByName.Remove(number);
                        numsByName.Insert(0, number);
                    }
                    else
                    {
                        numsByName.Insert(0, number);
                    }

                    if (numsByName.Count == 6)
                        numsByName.RemoveAt(5);
                }
                else
                {
                    numbersByName[name] = new List<string>() { number } ;
                }
            }

            foreach (var numbersByNameKv in numbersByName)
            {
                Console.WriteLine(numbersByNameKv.Key + ": " + numbersByNameKv.Value.Count.ToString() + " " + String.Join(" ", numbersByNameKv.Value));
            }


        }
    }

}