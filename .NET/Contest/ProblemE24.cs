//using System;
//using System.Collections.Generic;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        int testCaseCount = int.Parse(Console.ReadLine());

//        for (int i = 0; i < testCaseCount; i++)
//        {
//            Console.ReadLine();
//            WriteTimesOfEnd();
//        }
//    }

//    private static void WriteTimesOfEnd()
//    {
//        string[] threadCountAndTaskCount = Console.ReadLine().Split(' ');
//        int threadCount = int.Parse(threadCountAndTaskCount[0]);
//        int taskCount = int.Parse(threadCountAndTaskCount[1]);

//        var threads = new long[threadCount];
//        long[] resTimesOfEnd = new long[taskCount];
//        long fasterThreadEndTime = 0;
//        for (int i = 0; i < taskCount; i++)
//        {
//            string[] td = Console.ReadLine().Split(' ');

//            long strtTime = long.Parse(td[0]);
//            long execTime = long.Parse(td[1]);

//            if (strtTime < fasterThreadEndTime)
//                fasterThreadEndTime += execTime;
//            else
//                fasterThreadEndTime = strtTime + execTime;

//            resTimesOfEnd[i] = fasterThreadEndTime;

//            threads[0] = fasterThreadEndTime;
//            Array.Sort(threads);
//            fasterThreadEndTime = threads[0];
//        }

//        Console.WriteLine(String.Join(" ", resTimesOfEnd));
//    }
//}