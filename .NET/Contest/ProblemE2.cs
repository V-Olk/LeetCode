using System;

public class Program222
{
    public static void Main222(string[] args)
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
        string[] threadCountAndTaskCount = Console.ReadLine().Split(' ');
        int threadCount = int.Parse(threadCountAndTaskCount[0]);
        int taskCount = int.Parse(threadCountAndTaskCount[1]);

        int[] threads = new int[threadCount];
        int[] resTimesOfEnd = new int[taskCount];
        for (int i = 0; i < taskCount; i++)
        {
            string[] td = Console.ReadLine().Split(' ');

            int strtTime = int.Parse(td[0]);
            int execTime = int.Parse(td[1]);

            int threadId = GetFasterThreadId(threads);

            int curEndTime = threads[threadId];

            if (strtTime < curEndTime)
                curEndTime += execTime;
            else
                curEndTime = strtTime + execTime;

            threads[threadId] = curEndTime;
            resTimesOfEnd[i] = curEndTime;
        }

        Console.WriteLine(String.Join(" ", resTimesOfEnd));
    }

    private static int GetFasterThreadId(int[] threads)
    {
        int minValue = Int32.MaxValue;
        int minIndex = 0;
        for (int i = 0; i < threads.Length; i++)
        {
            int curEndTime = threads[i];
            if (curEndTime == 0)
                return i;

            if (curEndTime < minValue)
            {
                minValue = curEndTime;
                minIndex = i;
            }
        }

        return minIndex;
    }
}
