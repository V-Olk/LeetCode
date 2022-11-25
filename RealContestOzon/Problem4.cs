using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

public class Program112312
{
    private static HashSet<string> nicks;
    private static readonly HashSet<int> valid = new HashSet<int>();


    public static void Main423423()
    {
        valid.Add(45);
        valid.Add(95);

        for (int i = 48; i <= 57; i++)
        {
            valid.Add(i);
        }

        for (int i = 97; i <= 122; i++)
        {
            valid.Add(i);
        }

        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {

            var nicksCounts = int.Parse(Console.ReadLine());

            nicks = new HashSet<string>();

            for (int j = 0; j < nicksCounts; j++)
            {
                CheckNick();
            }
        }
    }

    private static void CheckNick()
    {
        string nick = Console.ReadLine().ToLowerInvariant();

        if (nicks.Contains(nick))
        {
            Console.WriteLine("no");
            return;
        }

        if (nick.Length is < 2 or > 24)
        {
            Console.WriteLine("no");
            return;
        }

        if (nick[0] == '-')
        {
            Console.WriteLine("no");
            return;
        }

        for (int k = 0; k < nick.Length; k++)
        {
            int ch = (int)nick[k];

            if (!valid.Contains(ch))
            {
                Console.WriteLine("no");
                return;
            }
        }

        nicks.Add(nick);
        Console.WriteLine("yes");
    }
}