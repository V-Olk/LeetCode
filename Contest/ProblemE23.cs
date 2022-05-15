using System;
using System.Linq;

public class Program336
{
    public static void Main336(string[] args)
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

        long[] resTimesOfEnd = new long[taskCount];

        var heap = new long[threadCount];
        long threadEndTime = Console.ReadLine().Split(' ').Select(l => long.Parse(l)).Sum();
        heap[0] = threadEndTime;
        resTimesOfEnd[0] = threadEndTime;

        var threads = new EasyBianaryHeap(heap);
        for (int i = 1; i < taskCount; i++)
        {
            string[] td = Console.ReadLine().Split(' ');

            long strtTime = long.Parse(td[0]);
            long execTime = long.Parse(td[1]);

            threadEndTime = threads.Peek();

            if (strtTime < threadEndTime)
                threadEndTime += execTime;
            else
                threadEndTime = strtTime + execTime;

            threads.Update(threadEndTime);
            resTimesOfEnd[i] = threadEndTime;
        }

        Console.WriteLine(String.Join(" ", resTimesOfEnd));
    }
}

internal class EasyBianaryHeap// : IEnumerable<>
{
    private readonly long[] _items;

    public EasyBianaryHeap(long[] items)
    {
        _items = items;

        ReCalculateDown();
    }

    internal long Peek() => _items[0];

    internal void Update(long minItemNewValue)
    {
        if (_items[0] == minItemNewValue)
            return;

        _items[0] = minItemNewValue;

        ReCalculateDown();
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _items.Length;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _items.Length;

    private long GetLeftChild(int elementIndex) => _items[GetLeftChildIndex(elementIndex)];
    private long GetRightChild(int elementIndex) => _items[GetRightChildIndex(elementIndex)];

    private void ReCalculateDown()
    {
        if (_items.Length == 0)
            return;

        int index = 0;
        while (HasLeftChild(index))
        {
            var smallerIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
            {
                smallerIndex = GetRightChildIndex(index);
            }

            if (_items[smallerIndex] >= _items[index])
            {
                break;
            }

            SwapValues(smallerIndex, index);
            index = smallerIndex;
        }
    }

    private void SwapValues(int currentIndex, int parentIndex)
        => (_items[parentIndex], _items[currentIndex]) = (_items[currentIndex], _items[parentIndex]);


}
