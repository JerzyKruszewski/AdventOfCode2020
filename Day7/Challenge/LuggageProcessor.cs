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
                        CanContainsBags = new List<BagConnection>()
                    };

                    for (int i = 1; i < parsedBag.Length; i++)
                    {
                        if (parsedBag[i].Contains("no"))
                        {
                            bagColor.CanContainsBags.Add(new BagConnection()
                            {
                                Code = parsedBag[i].Trim(),
                                Quantity = 0
                            });
                        }
                        else
                        {
                            string[] parsedWithQuantity = parsedBag[i].Split(" ");

                            bagColor.CanContainsBags.Add(new BagConnection()
                            {
                                Code = parsedBag[i].Remove(0, parsedWithQuantity[0].Length).Trim(),
                                Quantity = int.Parse(parsedWithQuantity[0])
                            });
                        }
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
                        if (globalBag.CanContainsBags.SingleOrDefault(b => b.Code == bag) != null && bag != globalBag.Code)
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

        /*
7. shiny gold bags contain 2 dark red bags.
6. dark red bags contain 2 dark orange bags.
5. dark orange bags contain 2 dark yellow bags.
4. dark yellow bags contain 2 dark green bags.
3. dark green bags contain 2 dark blue bags.
2. dark blue bags contain 2 dark violet bags.
1. dark violet bags contain no other bags.

2. quantity + 1 = 3
3. (2.) * quantity + 1 = 7
4. (3.) * quantity + 1 = 15
5. (4.) * quantity + 1 = 31
6. (5.) * quantity + 1 = 63
7. (6.) * quantity = 126
        */
        public static int HowManyBagsCouldBagWithGivenCodeContains(string code)
        {
            int quantity = 0;

            BagColor bagColor = _bagColors.SingleOrDefault(b => b.Code == code);

            if (bagColor == null)
            {
                return 0;
            }

            foreach (BagConnection connection in bagColor.CanContainsBags)
            {
                //I didn't understand a sequense so the following formula was based on u/Zuuou solution. Thank you very much Zuuou! 
                //https://www.reddit.com/r/adventofcode/comments/k8a31f/2020_day_07_solutions/gexs8nu?utm_source=share&utm_medium=web2x&context=3
                quantity += connection.Quantity * (HowManyBagsCouldBagWithGivenCodeContains(connection.Code) + 1);
            }

            return quantity;
        }
    }
}
