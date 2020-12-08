using System;
using AdventOfCode2020.Day8.Challenge;

namespace AdventOfCode2020.Day8
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {new HandheldBootHandler().GetAccumulatorValue()}");
            Console.WriteLine($"Second Challenge: {new HandheldBootHandler().FixSequence()}");
        }
    }
}
