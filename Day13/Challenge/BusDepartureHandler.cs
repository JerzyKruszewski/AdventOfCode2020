using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day13.Challenge
{
    public class BusDepartureHandler
    {
        private int _timestamp;
        private readonly IList<Bus> _buses;

        public BusDepartureHandler(int noOfChallenge)
        {
            _buses = PopulateBuses(noOfChallenge);
        }

        private string GetInput()
        {
            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                _timestamp = int.Parse(reader.ReadLine());

                return reader.ReadLine();
            }
        }

        private List<Bus> PopulateBuses(int noOfChallenge, string busesId = "")
        {
            if (string.IsNullOrEmpty(busesId))
            {
                busesId = GetInput();
            }

            List<Bus> buses = new List<Bus>();

            string[] busesIds = busesId.Split(',');

            foreach (string busId in busesIds)
            {
                if (busId == "x")
                {
                    if (noOfChallenge == 2)
                    {
                        buses.Add(null);
                    }

                    continue;
                }

                int id = int.Parse(busId);

                buses.Add(new Bus()
                {
                    Id = id,
                    Index = buses.Count,
                    LastDepartureTimestamp = CalculateLastDeparture(id)
                });
            }

            buses.RemoveAll(b => b == null);

            return buses;
        }

        private int CalculateLastDeparture(int id)
        {
            return _timestamp / id * id;
        }

        public int GetNextBusIdMultipliedByWaitTime()
        {
            int nextDepartureTimestamp = _buses.Min(b => b.NextDepartureTimestamp);
            Bus nextBus = _buses.SingleOrDefault(b => b.NextDepartureTimestamp == nextDepartureTimestamp);

            return nextBus.Id * (nextDepartureTimestamp - _timestamp);
        }

        //Faster
        public long FindEarliestTimestamp(string busesId = "")
        {
            IList<Bus> buses;

            if (string.IsNullOrEmpty(busesId))
            {
                buses = _buses;
            }
            else
            {
                buses = PopulateBuses(2, busesId);
            }

            long timestamp = 0;
            long step = buses[0].Id;

            foreach (Bus bus in buses.Skip(1))
            {
                while ((timestamp + bus.Index) % bus.Id != 0)
                {
                    timestamp += step;
                }

                step *= bus.Id;
            }

            return timestamp;
        }

        //Slower Brute force (like 6-7 hours)
        public long GetEarliestDepartureFromPart2(string busesId = "")
        {
            IList<Bus> buses;

            if (string.IsNullOrEmpty(busesId))
            {
                buses = _buses;
            }
            else
            {
                buses = PopulateBuses(2, busesId);
            }

            Bus busWithMaxId = FindBusWithMaxId(buses);

            for (long i = -busWithMaxId.Index; true; i += busWithMaxId.Id)
            {
                if (i % buses[0].Id != 0)
                {
                    continue;
                }

                bool isValid = true;

                foreach (Bus item in buses)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if ((i + item.Index) % item.Id != 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    return i;
                }
            }
        }

        private Bus FindBusWithMaxId(IList<Bus> buses)
        {
            Bus maxIdBus = buses[0];

            for (int i = 1; i < buses.Count; i++)
            {
                if (buses[i] == null)
                {
                    continue;
                }

                if (buses[i].Id >= maxIdBus.Id)
                {
                    maxIdBus = buses[i];
                }
            }

            return maxIdBus;
        }
    }
}
