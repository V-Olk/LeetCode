using System;
using System.Linq;

public class ProgramC
{
    public static void Main2()
    {
        Console.ReadLine();

        int[] encodedVals = Console.ReadLine().Split(' ').Select(imp => Int32.Parse(imp)).ToArray();
        if (encodedVals.Length == 0)
            return;

        int[] decodedVals = {};

        for (int i = 0; i <= encodedVals.Length; i++)
            if (TryDecode(encodedVals, i, out decodedVals))
                break;

        Console.WriteLine(String.Join(" ", decodedVals));
    }

    private static bool TryDecode(int[] encodedVals, int zeroPosition, out int[] decodedVals)
    {
        decodedVals = new int[encodedVals.Length + 1];
        decodedVals[zeroPosition] = 0;

        for (int i = zeroPosition; i < encodedVals.Length; i++)
        {
            int nextDecoded = encodedVals[i] + decodedVals[i];
            if (nextDecoded < 0)
                return false;

            decodedVals[i + 1] = nextDecoded;
        }

        for (int i = zeroPosition; i > 0; i--)
        {
            int prevDecoded = decodedVals[i] - encodedVals[i - 1];
            if (prevDecoded < 0)
                return false;

            decodedVals[i - 1] = prevDecoded;
        }

        return true;
    }
}