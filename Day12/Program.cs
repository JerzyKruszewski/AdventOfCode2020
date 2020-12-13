using System;
using System.Collections.Generic;
using AdventOfCode2020.Day12.Challenge;

namespace AdventOfCode2020.Day12
{
    internal class Program
    {
        private static void Main()
        {
            IList<ShipMove> list = new List<ShipMove>()
            {
                ShipNavigationHandler.ParseShipMove("F10"),
                ShipNavigationHandler.ParseShipMove("N3"),
                ShipNavigationHandler.ParseShipMove("F7"),
                ShipNavigationHandler.ParseShipMove("R90"),
                ShipNavigationHandler.ParseShipMove("F11"),
            };

            Console.WriteLine($"First Challenge Test: {ShipNavigationHandler.GetDistance(1, list)}");
            Console.WriteLine($"First Challenge: {ShipNavigationHandler.GetDistance(1)}");
            Console.WriteLine($"Second Challenge Test: {ShipNavigationHandler.GetDistance(2, list)}");
            Console.WriteLine($"Second Challenge: {ShipNavigationHandler.GetDistance(2)}");
        }
    }
}
