using System;

public class Program123123
{
    public static void Main123123(string[] args)
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            int[] blocksArray = GetBlocksArray(n, m);

            int[] waterArray = GetWaterArray(blocksArray, n);

            WriteResult(blocksArray, waterArray, n);
        }
    }

    private static int[] GetWaterArray(int[] blocksArray, int height)
    {
        int[] waterArray = new int[blocksArray.Length];

        for (int curHeight = 1; curHeight <= height; curHeight++)
        {
            int closerLeftWallPos = blocksArray[0] >= curHeight ? 0 : -1;
            int closerRightWallPos = GetCloserRightWall(0, curHeight, blocksArray);

            for (int j = 1; j < blocksArray.Length - 1; j++)
            {
                if (blocksArray[j] >= curHeight)
                {
                    closerLeftWallPos = j;
                    closerRightWallPos = GetCloserRightWall(j, curHeight, blocksArray);
                    continue;
                }

                if (closerLeftWallPos != -1 && closerRightWallPos != -1)
                    waterArray[j] += 1;
            }
        }

        return waterArray;
    }

    private static int GetCloserRightWall(int j, int curHeight, int[] blocksArray)
    {
        for (int i = j + 1; i < blocksArray.Length; i++)
        {
            if (blocksArray[i] >= curHeight)
                return i;
        }

        return -1;
    }

    private static void WriteResult(int[] blocksArray, int[] waterArray, int height)
    {
        //Console.WriteLine();//TODO: убрать

        //Console.WriteLine(String.Join(" ", blocksArray));
        //Console.WriteLine(String.Join(" ", waterArray));

        //Console.WriteLine();//TODO: убрат

        for (int i = height; i >= 1; i--)
        {
            char[] line = new char[blocksArray.Length];

            for (int j = 0; j < blocksArray.Length; j++)
            {
                int blAndWater = blocksArray[j] + waterArray[j];

                if (blAndWater < i)
                    line[j] = '.';
                else if (i > blocksArray[j] && i <= blAndWater)
                    line[j] = '~';
                else
                    line[j] = '*';
            }

            Console.WriteLine(line);
        }

        Console.WriteLine();
    }

    private static int[] GetBlocksArray(int n, int m)
    {
        int[] blocksArray = new int[m];

        for (int i = 0; i < n; i++)
        {
            string lineInfo = Console.ReadLine();

            for (int j = 0; j < lineInfo.Length; j++)
            {
                char curChar = lineInfo[j];

                if (curChar == '*')
                    blocksArray[j] += 1;
            }
        }

        return blocksArray;
    }

}
