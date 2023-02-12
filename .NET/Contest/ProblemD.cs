using System;
using System.Collections.Generic;

public class ProgramD
{
    public static void Main11()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();

        var charCountByChar = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (charCountByChar.ContainsKey(s[i]))
                charCountByChar[s[i]] += 1;
            else
                charCountByChar[s[i]] = 1;
        }

        char[] result = new char[s.Length];
        var greenIndexes = new HashSet<int>();
        for (int i = 0; i < s.Length; i++)
        {
            char curT = t[i];

            if (s[i] != curT)
                continue;

            result[i] = 'G';
            greenIndexes.Add(i);
            charCountByChar[curT] -= 1;
        }


        for (int i = 0; i < s.Length; i++)
        {
            if (greenIndexes.Contains(i))
                continue;

            char curT = t[i];

            if (charCountByChar.TryGetValue(curT, out int count) && count > 0)
            {
                result[i] = 'Y';
                charCountByChar[curT] -= 1;
                continue;
            }

            result[i] = '.';
        }

        Console.WriteLine(result);
    }
}