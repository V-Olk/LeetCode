using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program23432
{

    public static void Main(string[] args)
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            //Console.ReadLine();
            Console.WriteLine(ValidGame(out SortedSet<int> ships) ? $"YES{Environment.NewLine}{String.Join(" ", ships)}" : "NO");
        }
    }

    private static bool ValidGame(out SortedSet<int> ships)
    {
        ships = new SortedSet<int>();

        string[] nm = Console.ReadLine().Split(' ');

        int lines = int.Parse(nm[0]);
        int columns = int.Parse(nm[1]);
        
        bool[][] rows = new bool[lines][];

        for (int i = 0; i < lines; i++)
        {
            string strRow = Console.ReadLine();

            bool[] rrow = new bool[columns];

            for (int j = 0; j < columns; j++)
            {
                char ch = strRow[j];

                if (ch == '*')
                {
                    rrow[j] = true;
                }
            }

            rows[i] = rrow;
        }

        HashSet<(int, int)> checkedChars = new();
        for (int i = 0; i < rows.Length; i++)
        {
            bool[] row = rows[i];

            for (int j = 0; j < row.Length; j++)
            {
                if (checkedChars.Contains((i, j)))
                    continue;

                if (!row[j])
                {
                    checkedChars.Add((i, j));
                    continue;
                }

                if (!IsCorrectShip(rows, i, j, out int shipLength, out List<(int, int)> shipCoords))
                    return false;

                foreach (var chckd in shipCoords)
                    checkedChars.Add(chckd);

                ships.Add(shipLength);
            }

        }

        return true;
    }

    private static bool IsCorrectShip(bool[][] rows, int i, int j, out int shipLength, out List<(int, int)> shipCoords)
    {
        shipCoords = new List<(int, int)>();
        shipLength = 0;

        int countOfStarsAround = GetCountOfStarsAround(rows, i, j, out List<(int, int)> positionsOfStars);

        if (countOfStarsAround > 2)
            return false;

        if (countOfStarsAround == 0)
        {
            shipLength = 1;
            return true;
        }

        //TODO: если 1 или 2, проверить, подходит ли корабль под букву Г и размеры

        return false;
    }

    private static int GetCountOfStarsAround(bool[][] rows, int i, int j, out List<(int, int)> positionsOfStars)
    {
        int count = 0;
        positionsOfStars = new List<(int, int)>();

        for (int k = i - 1; k < i + 1; k++)
        {
            for (int l = j - 1; l < j + 1; l++)
            {
                if (k == i && l == j)
                    continue;

                if (k < 0 || l < 0 || k >= rows.Length || l >= rows[k].Length)
                    continue;

                if (rows[k][l])
                {
                    count++;
                    positionsOfStars.Add((k, l));
                }
            }
        }

        return count;

    }
}
