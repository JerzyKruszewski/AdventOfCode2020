using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day13.Challenge
{
    public class Bus
    {
        public int Id { init; get; }

        public int Index { init; get; }

        public int LastDepartureTimestamp { init; get; }

        public int NextDepartureTimestamp
        {
            get
            {
                return LastDepartureTimestamp + Id;
            }
        }
    }
}
