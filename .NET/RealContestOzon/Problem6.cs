using System;
using System.Collections.Generic;
using System.Linq;

public class Program1
{
    public static void Main123123()
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {

            int countOfTovars = int.Parse(Console.ReadLine());

            int[] prices = Console.ReadLine().Split(' ').Select(val => int.Parse(val)).ToArray();

            Dictionary<int, int> countByPrice = new Dictionary<int, int>();

            for (int j = 0; j < prices.Length; j++)
            {
                int price = prices[j];

                if (countByPrice.TryGetValue(price, out int count))
                {
                    countByPrice[price] = count + 1;
                }
                else
                {
                    countByPrice[price] = 1;
                }
            }

            var realCounts = countByPrice.Values.ToList();

            List<int> counts = GetCounts(realCounts);

            int finalPrice = GetFinalPrice(countByPrice.Keys.ToList(), counts);
            Console.WriteLine(finalPrice);
        }

    }

    private static int GetFinalPrice(List<int> prices, List<int> realCounts)
    {
        int sum = 0;

        for (int i = 0; i < prices.Count; i++)
        {
            sum += prices[i] * realCounts[i];
        }

        return sum;
    }


    private static List<int> GetCounts(List<int> realCounts)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < realCounts.Count; i++)
        {
            int realCount = realCounts[i];

            int kolvoTroek = realCount / 3;

            int finalCount = kolvoTroek * 2 + realCount % 3;

            result.Add(finalCount);
        }


        return result;
    }
}