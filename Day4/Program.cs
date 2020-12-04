using AdventOfCode2020.Day4.Challenge;
using System;

namespace AdventOfCode2020.Day4
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {PassportValidator.CountValidatedPassports(1)}");
            Console.WriteLine($"Second Challenge: {PassportValidator.CountValidatedPassports(2)}");
        }
    }
}
