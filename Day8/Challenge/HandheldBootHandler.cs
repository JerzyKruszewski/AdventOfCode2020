using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8.Challenge
{
    public class HandheldBootHandler
    {
        private int nextIndex;
        private int accumulator;
        private readonly IList<Operation> _bootSequence;
        private IList<int> operationIds;

        public HandheldBootHandler()
        {
            _bootSequence = new List<Operation>();

            PopulateBootSequence();
        }

        private void PopulateBootSequence()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _bootSequence.Add(OperationParser.ParseOperation(reader.ReadLine(), _bootSequence.Count));
                }
            }
        }

        private int PerformBootSequence()
        {
            nextIndex = 0;
            accumulator = 0;
            operationIds = new List<int>();

            while (true)
            {
                if (nextIndex >= _bootSequence.Count)
                {
                    return 0;
                }

                Operation nextOperation = _bootSequence[nextIndex];

                if (operationIds.Contains(nextOperation.Id))
                {
                    return -1;
                }

                PerformOperation(_bootSequence[nextIndex]);
            }
        }

        private void PerformOperation(Operation operation)
        {
            switch (operation.Code)
            {
                case "acc":
                    PerformAcceleration(operation);
                    nextIndex++;
                    break;
                case "jmp":
                    PerformJump(operation);
                    break;
                case "nop":
                    nextIndex++;
                    break;
                default:
                    break;
            }

            operationIds.Add(operation.Id);
        }

        private void PerformAcceleration(Operation operation)
        {
            _ = (operation.Symbol == '+') ? accumulator += operation.Value : accumulator -= operation.Value;
        }

        private void PerformJump(Operation operation)
        {
            _ = (operation.Symbol == '+') ? nextIndex += operation.Value : nextIndex -= operation.Value;
        }

        public int GetAccumulatorValue()
        {
            PerformBootSequence();

            return accumulator;
        }

        public int FixSequence()
        {
            foreach (Operation item in _bootSequence)
            {
                ChangeOperationCode(item);

                if (PerformBootSequence() == 0)
                {
                    return accumulator;
                }

                ChangeOperationCode(item);
            }

            return Int32.MinValue;
        }

        private void ChangeOperationCode(Operation operation)
        {
            if (operation.Code == "jmp")
            {
                operation.Code = "nop";
            }
            else if (operation.Code == "nop")
            {
                operation.Code = "jmp";
            }
        }
    }
}
