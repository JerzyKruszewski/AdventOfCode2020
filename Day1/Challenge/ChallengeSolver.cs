using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Day1.Challenge
{
    public class ChallengeSolver
    {
        private readonly IList<int> _input;

        public ChallengeSolver()
        {
            _input = new List<int>();

            PopulateInput();
        }

        private void PopulateInput()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _input.Add(int.Parse(reader.ReadLine()));
                }
            }
        }

        public int Solve(int noOfChallenge, int solveFor)
        {
            if (noOfChallenge == 1)
            {
                Tuple<int, int> result = FindPair(solveFor);
                return CalculateResult(result);
            }
            
            if (noOfChallenge == 2)
            {
                Tuple<int, int, int> result = FindTriple(solveFor);
                return CalculateResult(result);
            }

            throw new Exception("Couldn't find a challenge");
        }

        private Tuple<int, int> FindPair(int solveFor)
        {
            for (int i = 0; i < _input.Count - 1; i++)
            {
                for (int j = i + 1; j < _input.Count; j++)
                {
                    if (_input[i] + _input[j] == solveFor)
                    {
                        return new Tuple<int, int>(_input[i], _input[j]);
                    }
                }
            }

            throw new Exception($"Couldn't find pair that sum to {solveFor}");
        }

        private Tuple<int, int, int> FindTriple(int solveFor)
        {
            for (int i = 0; i < _input.Count - 2; i++)
            {
                for (int j = i + 1; j < _input.Count - 1; j++)
                {
                    for (int k = j + 1; k < _input.Count; k++)
                    {
                        if (_input[i] + _input[j] + _input[k] == solveFor)
                        {
                            return new Tuple<int, int, int>(_input[i], _input[j], _input[k]);
                        }
                    }
                }
            }

            throw new Exception($"Couldn't find triple that sum to {solveFor}");
        }

        private int CalculateResult(Tuple<int, int> pair)
        {
            return pair.Item1 * pair.Item2;
        }

        private int CalculateResult(Tuple<int, int, int> triple)
        {
            return triple.Item1 * triple.Item2 * triple.Item3;
        }
    }
}
