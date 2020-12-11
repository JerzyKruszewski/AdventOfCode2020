using System;
using AdventOfCode2020.Day11.Challenge;

namespace AdventOfCode2020.Day11
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {SeatOccupationModelingSystem.GetOccupiedSeats(0, 4, 1)}");
            Console.WriteLine($"Second Challenge: {SeatOccupationModelingSystem.GetOccupiedSeats(0, 5, 2)}");
        }
    }
}
