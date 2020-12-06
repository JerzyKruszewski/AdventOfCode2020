using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day6.Challenge
{
    public class PassengerGroup
    {
        public int Id { init; get; }

        public string CombinedAnswers { get; set; }

        public IList<Passenger> Passengers { init; get; }
    }
}
