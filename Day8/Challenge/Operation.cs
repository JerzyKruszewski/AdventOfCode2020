using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8.Challenge
{
    public class Operation
    {
        public int Id { init; get; }

        public string Code { get; set; }

        public char Symbol { init; get; }

        public int Value { init; get; }

        public override string ToString()
        {
            return $"{Id}| {Code} {Symbol}{Value}";
        }
    }
}
