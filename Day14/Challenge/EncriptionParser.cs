using System;
using System.Linq;

namespace AdventOfCode2020.Day14.Challenge
{
    public class EncriptionParser
    {
        public static int GetMemoryLenght(string[] input)
        {
            int lenght = 0;

            foreach (string line in input)
            {
                if (line.Contains('['))
                {
                    int index = line.IndexOf('[') + 1;
                    string number = line[index..line.IndexOf(']')];
                    int possibleNewLenght = int.Parse(number);

                    if (possibleNewLenght > lenght)
                    {
                        lenght = possibleNewLenght;
                    }
                }
            }

            return lenght + 1;
        }

        public static string GetMemoryMask(string input)
        {
            input = input.Replace(" ", "");
            int index = input.IndexOf('=') + 1;
            
            return input[index..];
        }

        public static int GetMemoryIndex(string input)
        {
            int index = input.IndexOf('[') + 1;
            string number = input[index..input.IndexOf(']')];
            return int.Parse(number);
        }

        public static long GetMemoryValue(string input)
        {
            input = input.Replace(" ", "");
            int index = input.IndexOf('=') + 1;
            string number = input[index..];
            return long.Parse(number);
        }

        public static string ConvertBitsToDecimalString(string bits)
        {
            long deci = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                {
                    deci += (long)Math.Pow(2, bits.Length - i - 1);
                }
            }

            return $"{deci}";
        }

        public static string ConvertDecimalToBitsString(string deciText)
        {
            string bits = "";
            long deci = long.Parse(deciText);

            while (deci > 0)
            {
                bits += $"{deci % 2}";
                deci /= 2;
            }

            while (bits.Length != 36)
            {
                bits += "0";
            }

            return new string(bits.Reverse().ToArray());
        }
    }
}
