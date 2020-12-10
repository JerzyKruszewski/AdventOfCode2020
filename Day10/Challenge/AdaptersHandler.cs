using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day10.Challenge
{
    public class AdaptersHandler
    {
        private static readonly List<int> _adaptersJoltage;
        private static List<long> pathsLenghts;

        static AdaptersHandler()
        {
            _adaptersJoltage = new List<int>();

            PopulateAdaptersJoltage();
        }

        private static void PopulateAdaptersJoltage()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _adaptersJoltage.Add(int.Parse(reader.ReadLine()));
                }
            }
        }

        public static int OneJoltDifferencesMultipliedByThreeJoltDiff(int joltage, List<int> adaptersJoltage = null)
        {
            //For unit tests
            if (adaptersJoltage == null)
            {
                adaptersJoltage = _adaptersJoltage;
            }

            int oneJoltDiff = 0;
            int threeJoltDiff = 0;

            foreach (int adapterJoltage in Utils.Sort(adaptersJoltage))
            {
                switch (adapterJoltage - joltage)
                {
                    case 1:
                        oneJoltDiff++;
                        break;
                    case 2:
                        break;
                    case 3:
                        threeJoltDiff++;
                        break;
                    default:
                        throw new Exception($"Too much difference between {joltage} and {adapterJoltage}");
                }

                joltage = adapterJoltage;
            }

            threeJoltDiff++; //build-in adapter

            return oneJoltDiff * threeJoltDiff;
        }

        //I was struggling with part 2 for at least 7h... I found u/thatsumoguy07 solution on reddit. I just tweaked it to better work with list.
        //https://www.reddit.com/r/adventofcode/comments/ka8z8x/2020_day_10_solutions/gfads8a/?context=3
        public static long FindQuantityOfDifferentAdapterCombinations(List<int> adaptersJoltage = null)
        {
            //For unit tests
            if (adaptersJoltage == null)
            {
                adaptersJoltage = _adaptersJoltage;
            }

            adaptersJoltage.Add(0);

            adaptersJoltage = Utils.Sort(adaptersJoltage); //BubbleSort

            PopulatePaths(adaptersJoltage);

            for (int i = 1; i < adaptersJoltage.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Math.Abs(adaptersJoltage[i] - adaptersJoltage[j]) <= 3)
                    {
                        pathsLenghts[i] += pathsLenghts[j];
                    }
                }
            }

            return pathsLenghts[^1];
        }

        private static void PopulatePaths(List<int> adaptersJoltage)
        {
            pathsLenghts = new List<long>();

            for (int i = 0; i < adaptersJoltage.Count; i++)
            {
                if (i == 0)
                {
                    pathsLenghts.Add(1L);
                }
                else
                {
                    pathsLenghts.Add(0L);
                }
            }
        }
    }
}
