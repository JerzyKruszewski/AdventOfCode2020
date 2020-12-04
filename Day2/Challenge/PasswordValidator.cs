using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day2.Challenge
{
    public class PasswordValidator
    {
        private static readonly IList<string> _passwords;

        static PasswordValidator()
        {
            _passwords = new List<string>();

            PopulatePasswords();
        }

        private static void PopulatePasswords()
        {
            using (StreamReader reader = new StreamReader("./Challenge/passwords.txt", Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    _passwords.Add(reader.ReadLine());
                }
            }
        }

        public static int CountValidatePasswords(int noOfChallenge)
        {
            int validate = 0;

            foreach (string password in _passwords)
            {
                string[] pass = PasswordParser.DividePassword(password);
                pass[1] = PasswordParser.RemoveUnnecessaryCharacters(pass[1]);
                Tuple<int, int> tuple = PasswordParser.FindHowManyTimesCanCharacterOccur(pass[0]);

                if (noOfChallenge == 1)
                {
                    int occurances = CountCharacters(pass[1][0], pass[2]);

                    if (occurances >= tuple.Item1 && occurances <= tuple.Item2)
                    {
                        validate++;
                    }
                }
                else if (noOfChallenge == 2)
                {
                    if ((pass[2][tuple.Item1 - 1] == pass[1][0] && pass[2][tuple.Item2 - 1] != pass[1][0])
                    || (pass[2][tuple.Item1 - 1] != pass[1][0] && pass[2][tuple.Item2 - 1] == pass[1][0]))
                    {
                        validate++;
                    }
                }
            }

            return validate;
        }

        private static int CountCharacters(char character, string password)
        {
            int occurances = 0;

            foreach (char item in password)
            {
                if (item == character)
                {
                    occurances++;
                }
            }

            return occurances;
        }
    }
}
