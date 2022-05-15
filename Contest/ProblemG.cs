using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static readonly int[][] _winPositions = new int[8][];

    public static void Main222(string[] args)
    {
        InintializeWinPos();

        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            Console.ReadLine();
            Console.WriteLine(ValidGame() ? "yes" : "no");
        }
    }

    private static void InintializeWinPos()
    {
        _winPositions[0] = new [] { 0, 1, 2 };
        _winPositions[1] = new[] { 3, 4, 5 };
        _winPositions[2] = new[] { 6, 7, 8 };

        _winPositions[3] = new[] { 0, 3, 6 };
        _winPositions[4] = new [] { 1, 4, 7 };
        _winPositions[5] = new [] { 2, 5, 8 };

        _winPositions[6] = new[] { 0, 4, 8 };
        _winPositions[7] = new [] { 6, 4, 2 };
    }

    private static bool ValidGame()
    {
        GetMatrix(out HashSet<int> oPos, out HashSet<int> xPos);

        if (oPos.Count > xPos.Count || Math.Abs(oPos.Count - xPos.Count) > 1)
            return false;

        int xCountOfWins = GetCountOfWins(xPos);
        if (xCountOfWins > 1)
            return false;

        int oCountOfWins = GetCountOfWins(oPos);
        if (oCountOfWins > 1)
            return false;

        if (xCountOfWins != 0 && oCountOfWins != 0)
            return false;

        if (xCountOfWins == 1 && xPos.Count == oPos.Count)
            return false;

        if (oCountOfWins == 1 && xPos.Count != oPos.Count)
            return false;

        return true;
    }

    private static int GetCountOfWins(HashSet<int> positions)
    {
        int winsCount = 0;

        for (int i = 0; i < _winPositions.Length; i++)
        {
            int[] winPos = _winPositions[i];

            int winPosInPositions = 0;

            for (int j = 0; j < winPos.Length; j++)
            {
                if (!positions.Contains(winPos[j]))
                    break;

                winPosInPositions++;
            }

            if (winPosInPositions != winPos.Length)
                continue;

            if (++winsCount > 1)
                return winsCount;
        }

        return winsCount;
    }

    private static void GetMatrix(out HashSet<int> oPos, out HashSet<int> xPos)
    {
        List<int> oPosLst = new List<int>();
        List<int> xPosLst = new List<int>();

        int matrxPos = 0;
        for (int i = 0; i < 3; i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < 3; j++)
            {
                switch (line[j])
                {
                    case 'X':
                        xPosLst.Add(matrxPos);
                        break;
                    case '0':
                        oPosLst.Add(matrxPos);
                        break;
                }

                matrxPos++;
            }
        }

        oPos = oPosLst.ToHashSet();
        xPos = xPosLst.ToHashSet();
    }
}
