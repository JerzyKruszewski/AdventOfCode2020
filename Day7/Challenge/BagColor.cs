using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day7.Challenge
{
    public class BagColor
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public IList<string> CanContainsBags { get; set; }
    }
}
