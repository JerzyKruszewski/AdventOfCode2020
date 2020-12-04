using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day3.Challenge
{
    public class PathChecker
    {
        private static readonly IList<string> _map;

        static PathChecker()
        {
            _map = new List<string>();

            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _map.Add(reader.ReadLine());
                }
            }
        }

        public static int CountTreesOnPath(int right, int bottom)
        {
            int xCord = 0;
            int yCord = 0;
            int trees = 0;

            while (yCord < _map.Count)
            {
                if (_map[yCord][xCord] == '#')
                {
                    trees++;
                }

                xCord = (xCord + right) % _map[yCord].Length;
                yCord += bottom;
            }

            return trees;
        }

        public static long MultiplyTreesInPaths(params Tuple<int, int>[] rightBottomPairs)
        {
            long result = 1;

            foreach (Tuple<int, int> item in rightBottomPairs)
            {
                result *= CountTreesOnPath(item.Item1, item.Item2);
            }

            return result;
        }
    }
}
