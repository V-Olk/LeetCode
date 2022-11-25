using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program13ц24
{
    private static Dictionary<string, Module> _buildStatusByModuleName;

    public static void Main234234234()
    {
        int testCaseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < testCaseCount; i++)
        {
            Console.ReadLine();

            var moduleCounts = int.Parse(Console.ReadLine());

            _buildStatusByModuleName = new Dictionary<string, Module>(moduleCounts);

            for (int j = 0; j < moduleCounts; j++)
            {
                ReadModule();
                Console.WriteLine();
            }

            moduleCounts = int.Parse(Console.ReadLine());

            for (int j = 0; j < moduleCounts; j++)
            {
                WriteAssembly();
                Console.WriteLine();
            }
        }
    }

    private static void ReadModule()
    {
        string[] input = Console.ReadLine().Split(' ');

        string mainModule = input[0].Remove(input[0].Length - 1);
        _buildStatusByModuleName[mainModule] = new Module(mainModule, input.Skip(1).ToArray());
    }

    private static void WriteAssembly()
    {

        string moduleName = Console.ReadLine();

        var buildRes = _buildStatusByModuleName[moduleName].Build();

        if (buildRes.Length == 0)
        {
            Console.WriteLine("0");
            return;
        }

        Console.WriteLine(buildRes.Length + " " + String.Join(" ", buildRes));
    }

    internal class Module
    {
        private string _name;

        private string[] _dependencies;

        private bool _builded;

        internal Module(string name, string[] dependencies)
        {
            _name = name;
            _dependencies = dependencies;
        }

        internal string[] Build()
        {
            if (_builded)
                return Array.Empty<string>();

            _builded = true;

            List<string> dep = new List<string>();

            for (int i = 0; i < _dependencies.Length; i++)
            {
                string depName = _dependencies[i];

                dep.AddRange(_buildStatusByModuleName[depName].Build());
            }

            dep.Add(_name);

            return dep.ToArray();
        }
    }
}

