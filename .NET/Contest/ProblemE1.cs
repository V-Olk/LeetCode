using System;

public class Program66
{
    public static void Main66(string[] args)
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            Console.ReadLine();
            WriteTimesOfEnd();
        }
    }

    private static void WriteTimesOfEnd()
    {
        int taskCount = int.Parse(Console.ReadLine());

        int[] resTimesOfEnd = new int[taskCount];
        int curEndTime = 0;
        for (int i = 0; i < taskCount; i++)
        {
            string[] td = Console.ReadLine().Split(' ');

            int strtTime = int.Parse(td[0]);
            int execTime = int.Parse(td[1]);

            if (strtTime < curEndTime)
                curEndTime += execTime;
            else
                curEndTime = strtTime + execTime;

            resTimesOfEnd[i] = curEndTime;
        }

        Console.WriteLine(String.Join(" ", resTimesOfEnd));
    }
}
