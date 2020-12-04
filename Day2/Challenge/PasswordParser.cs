using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day2.Challenge
{
    public class PasswordParser
    {
        public static string[] DividePassword(string password)
        {
            return password.Split(' ');
        }

        public static string RemoveUnnecessaryCharacters(string password)
        {
            return password.Replace(":", "");
        }

        public static Tuple<int, int> FindHowManyTimesCanCharacterOccur(string password)
        {
            string[] minmax = password.Split('-');

            return new Tuple<int, int>(int.Parse(minmax[0]), int.Parse(minmax[1]));
        }
    }
}
