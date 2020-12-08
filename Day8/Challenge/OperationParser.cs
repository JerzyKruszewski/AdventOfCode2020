using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8.Challenge
{
    public class OperationParser
    {
        public static Operation ParseOperation(string operCode, int nextId)
        {
            string[] operValueCode = operCode.Split(" ");
            char symbol = operValueCode[1][0];
            int value = int.Parse(operValueCode[1][1..]);

            Operation operation = new Operation()
            {
                Id = nextId,
                Code = operValueCode[0],
                Symbol = symbol,
                Value = value
            };

            return operation;
        }
    }
}
