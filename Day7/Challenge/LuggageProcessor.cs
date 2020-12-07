using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day7.Challenge
{
    public class LuggageProcessor
    {
        private static readonly IList<BagColor> _bagColors;

        static LuggageProcessor()
        {
            _bagColors = new List<BagColor>();

            PopulateBags();
        }

        private static void PopulateBags()
        {
            int id = 0;

            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    string[] parsedBag = LuggageParser.ParseBagEntry(reader.ReadLine());
                    string code = parsedBag[0].Trim();

                    BagColor bagColor = new BagColor()
                    {
                        Id = id,
                        Code = code,
                        CanContainsBags = new List<string>()
                    };

                    for (int i = 1; i < parsedBag.Length; i++)
                    {
                        bagColor.CanContainsBags.Add(parsedBag[i].Trim());
                    }

                    _bagColors.Add(bagColor);

                    id++;
                }
            }
        }

        public static int CountBagsThatCanContain(string code)
        {
            List<string> CanContainsBagsWithGivenCode = new List<string>()
            {
                code
            };

            List<string> temp = new List<string>();
            int i;

            do
            {
                i = 0;

                foreach (BagColor globalBag in _bagColors)
                {
                    foreach (string bag in CanContainsBagsWithGivenCode)
                    {
                        if (globalBag.CanContainsBags.Contains(bag) && bag != globalBag.Code)
                        {
                            temp.Add(globalBag.Code);
                        }
                    }

                    foreach (string bag in temp)
                    {
                        if (!CanContainsBagsWithGivenCode.Contains(bag))
                        {
                            CanContainsBagsWithGivenCode.Add(bag);
                            i++;
                        }
                    }

                    temp = new List<string>();
                }
            } while (i > 0);

            return CanContainsBagsWithGivenCode.Count - 1;
        }
    }
}
