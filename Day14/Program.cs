using AdventOfCode2020.Day14.Challenge;
using System;

namespace AdventOfCode2020.Day14
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {new EncriptionHandler(1).GetSumOfMemoryValues()} (Ground truth: {17028179706934})");
            Console.WriteLine($"Second Challenge: {new EncriptionHandler(2).GetSumOfMemoryValues()} (Ground truth: {3683236147222})");
        }
    }
}

