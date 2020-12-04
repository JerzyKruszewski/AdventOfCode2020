using System;
using AdventOfCode2020.Day3.Challenge;

namespace AdventOfCode2020.Day3
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {PathChecker.CountTreesOnPath(3, 1)}");
            Console.WriteLine(@$"Second Challenge: {PathChecker.MultiplyTreesInPaths(
                new Tuple<int, int>(1, 1), new Tuple<int, int>(3, 1), new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1), new Tuple<int, int>(1, 2))}");
        }
    }
}
