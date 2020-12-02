using System;
using AdventOfCode2020.Day1.Challenge;

namespace AdventOfCode2020.Day1
{
    internal class Program
    {
        private static void Main()
        {
            ShowResults();
        }

        private static void ShowResults()
        {
            ChallengeSolver challengeSolver = new ChallengeSolver();

            Console.WriteLine($"First challenge result: {challengeSolver.Solve(1, 2020)}");
            Console.WriteLine($"Second challenge result: {challengeSolver.Solve(2, 2020)}");
        }
    }
}
