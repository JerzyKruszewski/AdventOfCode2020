using System;
using AdventOfCode2020.Day9.Challenge;

namespace AdventOfCode2020.Day9
{
    internal class Program
    {
        private static void Main()
        {
            long invalidNumber = XMASEncription.CheckEncription(25);
            Console.WriteLine($"First Challenge: {invalidNumber}");
            Console.WriteLine($"Second Challenge: {XMASEncription.FindSumOfSequenceGapWithSum(invalidNumber)}");
        }
    }
}
