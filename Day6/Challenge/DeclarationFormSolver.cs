using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day6.Challenge
{
    public class DeclarationFormSolver
    {
        private static readonly IList<PassengerGroup> _passengerGroups;

        static DeclarationFormSolver()
        {
            _passengerGroups = new List<PassengerGroup>();

            PopulatePassengerGroups();
        }

        private static void PopulatePassengerGroups()
        {
            string content;

            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }

            string[] groupsContent = content.Split("\r\n\r\n");

            for (int i = 0; i < groupsContent.Length; i++)
            {
                PassengerGroup group = new PassengerGroup()
                {
                    Id = i,
                    CombinedAnswers = "",
                    Passengers = new List<Passenger>()
                };

                string[] passengerContent = groupsContent[i].Split("\r\n");

                for (int j = 0; j < passengerContent.Length; j++)
                {
                    group.Passengers.Add(new Passenger()
                    {
                        Id = j,
                        Answers = passengerContent[j]
                    });
                }

                _passengerGroups.Add(group);
            }
        }

        private static void FindCombinedAnswers(int noOfChallenge)
        {
            if (noOfChallenge == 1)
            {
                AnyYesAddsToCombinedAnswer();
            }
            else if (noOfChallenge == 2)
            {
                EveryYesAddsToCombinedAnswer();
            }
        }

        private static void AnyYesAddsToCombinedAnswer()
        {
            foreach (PassengerGroup group in _passengerGroups)
            {
                foreach (Passenger passenger in group.Passengers)
                {
                    foreach (char answer in passenger.Answers)
                    {
                        if (!group.CombinedAnswers.Contains(answer))
                        {
                            group.CombinedAnswers += answer;
                        }
                    }
                }
            }
        }

        private static void EveryYesAddsToCombinedAnswer()
        {
            foreach (PassengerGroup group in _passengerGroups)
            {
                foreach (char answer in group.Passengers[0].Answers)
                {
                    if (!group.CombinedAnswers.Contains(answer) && group.Passengers.All(p => p.Answers.Contains(answer)))
                    {
                        group.CombinedAnswers += answer;
                    }
                }
            }
        }

        public static int GetCombinedAnswersNumber(int noOfChallenge)
        {
            ResetCombinedAnswers();
            FindCombinedAnswers(noOfChallenge);

            int allAnswers = 0;

            foreach (PassengerGroup group in _passengerGroups)
            {
                allAnswers += group.CombinedAnswers.Length;
            }

            return allAnswers;
        }

        private static void ResetCombinedAnswers()
        {
            foreach (PassengerGroup group in _passengerGroups)
            {
                group.CombinedAnswers = "";
            }
        }
    }
}
