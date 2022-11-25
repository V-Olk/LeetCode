using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program1112
{
    private static BitArray _vagons;

    private static SortedSet<int> _freeKupe;

    public static void Main2342342()
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            Console.ReadLine();

            string[] nq = Console.ReadLine().Split(' ');

            int n = int.Parse(nq[0]);
            int q = int.Parse(nq[1]);

            _vagons = new BitArray(2*n + 1);
            _freeKupe = new SortedSet<int>();

            for (int j = 1; j <= n; j++)
                _freeKupe.Add(j);

            for (int j = 0; j < q; j++)
            {
                ProccessQuery();
                Console.WriteLine();
            }
        }
    }

    private static void ProccessQuery()
    {
        string strQuery = Console.ReadLine();

        if (strQuery[0] == '1')
        {
            int p = int.Parse(strQuery.Split(' ').Last());// - 1;

            if (_vagons[p])
            {
                Console.WriteLine("FAIL");
                return;
            }

            _vagons[p] = true;

            if (p % 2 != 0)
                p++;

            int kupeNum = p / 2;

            _freeKupe.Remove(kupeNum);

            Console.WriteLine("SUCCESS");

        }
        else if (strQuery[0] == '2')
        {
            int p = int.Parse(strQuery.Split(' ').Last());// - 1;

            if (_vagons[p])
            {
                _vagons[p] = false;

                int secPlace = p % 2 == 0 ? p -1 : p + 1;

                if (!_vagons[secPlace])
                {
                    if (secPlace < p)
                        secPlace = p;

                    _freeKupe.Add(secPlace / 2);
                    //_freeKupe = _freeKupe.OrderBy(el => el).ToHashSet();
                }

                Console.WriteLine("SUCCESS");
                return;
            }

            Console.WriteLine("FAIL");
            return;
        }
        else if (strQuery[0] == '3')
        {
            if (_freeKupe.Count == 0)
            {
                Console.WriteLine("FAIL");
                return;
            }

            int freeKupe = _freeKupe.First();
            _freeKupe.Remove(freeKupe);

            int firstPlace = freeKupe*2;
            int secPlaace = firstPlace - 1;

            _vagons[firstPlace] = true;
            _vagons[secPlaace] = true;

            Console.WriteLine($"SUCCESS {secPlaace}-{firstPlace}");

        }

    }
}

