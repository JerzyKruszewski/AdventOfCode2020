using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day14.Challenge
{
    public class EncriptionHandler
    {
        private readonly int _version;
        private readonly Dictionary<string, Dictionary<long, long>> _memory;

        public EncriptionHandler(int version)
        {
            _version = version;
            _memory = GetInput("./Challenge/input.txt");
        }

        public Dictionary<string, Dictionary<long, long>> GetInput(string inputPath)
        {
            return ParseInput(File.ReadAllLines(inputPath));
        }

        public Dictionary<string, Dictionary<long, long>> ParseInput(IEnumerable<string> input)
        {
            var result = new Dictionary<string, Dictionary<long, long>>();
            var currentMask = "";
            var currentMaskAddresses = new Dictionary<long, long>();
            foreach (string line in input)
            {
                if (line.StartsWith("mask"))
                {
                    if (!string.IsNullOrEmpty(currentMask))
                        result.Add(currentMask, currentMaskAddresses);
                    currentMask = EncriptionParser.GetMemoryMask(line);
                    currentMaskAddresses = new Dictionary<long, long>();
                }
                else if (line.StartsWith("mem["))
                {
                    long index = EncriptionParser.GetMemoryIndex(line);
                    long value = EncriptionParser.GetMemoryValue(line);

                    currentMaskAddresses.Add(index, value);
                }
            }
            result.Add(currentMask, currentMaskAddresses);

            return result;
        }

        public string MaskBits(string bits, string mask, int version)
        {
            string masked = "";

            for (int i = 0; i < mask.Length && i < bits.Length; i++)
            {
                if (version == 1)
                {
                    if (mask[i] == 'X')
                    {
                        masked += bits[i];
                    }
                    else
                    {
                        masked += mask[i];
                    }
                }
                else if (version == 2)
                {
                    if (mask[i] == '0')
                    {
                        masked += bits[i];
                    }
                    else
                    {
                        masked += mask[i];
                    }
                }
            }

            return masked;
        }

        public Dictionary<long, long> ProcessBitMask(Dictionary<long, long> memory, string mask, Dictionary<long, long> values)
        {
            foreach (var value in values)
            {
                if (_version == 1)
                {
                    string binary = EncriptionParser.ConvertDecimalToBitsString($"{value.Value}");
                    binary = MaskBits(binary, mask, _version);
                    memory[value.Key] = long.Parse(EncriptionParser.ConvertBitsToDecimalString(binary));
                }
                else
                {
                    string binary = EncriptionParser.ConvertDecimalToBitsString($"{value.Key}");
                    binary = MaskBits(binary, mask, _version);

                    foreach (string adress in MakeBitPermutations(binary))
                    {
                        memory[long.Parse(EncriptionParser.ConvertBitsToDecimalString(adress))] = value.Value;
                    }
                }
            }
            return memory;
        }

        public long GetSumOfMemoryValues(Dictionary<string, Dictionary<long, long>> input = null)
        {
            if (input == null)
            {
                input = _memory;
            }

            var memory = new Dictionary<long, long>();

            foreach (KeyValuePair<string, Dictionary<long, long>> maskWithMemoryParams in input)
            {
                memory = ProcessBitMask(memory, maskWithMemoryParams.Key, maskWithMemoryParams.Value);
            }

            return memory.Values.Sum();
        }

        public List<string> MakeBitPermutations(string item)
        {
            List<string> permutations = new List<string>()
            {
                item
            };

            while (true)
            {
                List<string> permutationsToAdd = new List<string>();
                List<string> permutationsToRemove = new List<string>();
                foreach (string permutation in permutations)
                {
                    if (permutation.Contains('X'))
                    {
                        permutationsToRemove.Add(permutation);
                        int index = permutation.IndexOf('X');
                        permutationsToAdd.Add($"{permutation.Substring(0, index)}0{permutation[(index + 1)..]}");
                        permutationsToAdd.Add($"{permutation.Substring(0, index)}1{permutation[(index + 1)..]}");
                        break;
                    }
                }
                permutations.AddRange(permutationsToAdd);
                permutations = permutations.Except(permutationsToRemove).ToList();
                if (permutations.All(p => !p.Contains('X')))
                {
                    break;
                }
            }

            return permutations;
        }
    }
}
