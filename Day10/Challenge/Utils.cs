using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day10.Challenge
{
    public class Utils
    {
        public static List<int> Sort(List<int> args)
        {
            if (args.Count < 2)
            {
                throw new ArgumentException("Table must have at least 2 elements");
            }

            int temp;

            for (int i = 0; i < args.Count - 1; i++)
            {
                for (int j = 1; j < args.Count - i; j++)
                {
                    if (args[j] < args[j - 1])
                    {
                        //Swap
                        temp = args[j - 1];
                        args[j - 1] = args[j];
                        args[j] = temp;
                    }
                }
            }

            return args;
        }
    }
}
