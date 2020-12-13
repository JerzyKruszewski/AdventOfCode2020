using AdventOfCode2020.Day13.Challenge;
using System;

namespace AdventOfCode2020.Day13
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {new BusDepartureHandler(1).GetNextBusIdMultipliedByWaitTime()}");
            Console.WriteLine($"Second Challenge: {new BusDepartureHandler(2).FindEarliestTimestamp()}");
            //Console.WriteLine($"Second Challenge: {new BusDepartureHandler(2).GetEarliestDepartureFromPart2()}");
        }
    }
}
