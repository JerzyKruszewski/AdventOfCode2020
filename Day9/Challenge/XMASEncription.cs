using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day9.Challenge
{
    public class XMASEncription
    {
        private static readonly IList<long> _encriptionSequence;

        static XMASEncription()
        {
            _encriptionSequence = new List<long>();

            PopulateEncriptionSequence();
        }

        private static void PopulateEncriptionSequence()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _encriptionSequence.Add(long.Parse(reader.ReadLine()));
                }
            }
        }

        public static long CheckEncription(int preambleLength)
        {
            List<long> preamble = _encriptionSequence.Take(preambleLength).ToList();

            foreach (long encriptionValue in _encriptionSequence.Skip(preambleLength))
            {
                if (!FindSum(encriptionValue, preamble))
                {
                    return encriptionValue;
                }

                preamble.RemoveAt(0);
                preamble.Add(encriptionValue);
            }

            return long.MinValue;
        }

        private static bool FindSum(long encriptionValue, List<long> preamble)
        {
            for (int i = 0; i < preamble.Count - 1; i++)
            {
                for (int j = 1; j < preamble.Count; j++)
                {
                    if (preamble[i] + preamble[j] == encriptionValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static long FindSumOfSequenceGapWithSum(long expectedSum)
        {
            List<long> sequence = new List<long>();

            for (int i = 0; i < _encriptionSequence.Count; i++)
            {
                foreach (long enctiptionValue in _encriptionSequence.Skip(i))
                {
                    if (enctiptionValue == expectedSum)
                    {
                        sequence.Clear();
                        continue;
                    }

                    sequence.Add(enctiptionValue);
                    long sumOfSequence = sequence.Sum();

                    if (sumOfSequence == expectedSum)
                    {
                        return sequence.Max() + sequence.Min();
                    }
                    else if (sumOfSequence > expectedSum)
                    {
                        sequence.RemoveAt(0);
                    }
                }
            }

            return long.MinValue;
        }
    }
}
