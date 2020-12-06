using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day5.Challenge
{
    public class PlaneSeatChecker
    {
        private static readonly IList<PlaneSeat> _seats;

        static PlaneSeatChecker()
        {
            _seats = new List<PlaneSeat>();

            PopulateSeats();
        }

        private static void PopulateSeats()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    string code = reader.ReadLine();

                    _seats.Add(new PlaneSeat()
                    {
                        Id = CheckSeatId(code),
                        SeatCode = code
                    });
                }
            }
        }

        private static int CheckSeatId(string code)
        {
            int maxRows = 0;
            int maxColumns = 0;

            foreach (char character in code)
            {
                if (character == 'F' || character == 'B')
                {
                    maxRows++;
                }
                else if (character == 'L' || character == 'R')
                {
                    maxColumns++;
                }
            }

            string rowsCode = code.Substring(0, maxRows);
            string columnsCode = code.Substring(maxRows, maxColumns);
            maxRows = (int)Math.Pow(2, maxRows) - 1;
            maxColumns = (int)Math.Pow(2, maxColumns) - 1;
            int row = FindSeat(rowsCode, 0, maxRows);
            int column = FindSeat(columnsCode, 0, maxColumns);

            return row * 8 + column;
        }

        private static int FindSeat(string code, int min, int max)
        {
            if (min == max)
            {
                return min;
            }

            if (code.StartsWith('F'))
            {
                return FindSeat(code.Remove(0, 1), min, (int)Math.Floor((max + min) / 2.0));
            }
            if (code.StartsWith('B'))
            {
                return FindSeat(code.Remove(0, 1), (int)Math.Ceiling((max + min) / 2.0), max);
            }
            if (code.StartsWith('L'))
            {
                return FindSeat(code.Remove(0, 1), min, (int)Math.Floor((max + min) / 2.0));
            }
            if (code.StartsWith('R'))
            {
                return FindSeat(code.Remove(0, 1), (int)Math.Ceiling((max + min) / 2.0), max);
            }

            throw new Exception($"Recursion Exception: {code}|{min}|{max}");
        }

        public static int GetMaxId()
        {
            return _seats.Max(s => s.Id);
        }

        public static int FindYourSeatId()
        {
            foreach (PlaneSeat seat in _seats)
            {
                if (_seats.SingleOrDefault(s => s.Id == seat.Id + 1) == null &&
                    _seats.SingleOrDefault(s => s.Id == seat.Id + 2) != null)
                {
                    return seat.Id + 1;
                }
            }

            throw new Exception("Couldn't find your seat");
        }
    }
}
