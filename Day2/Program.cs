using System;
using AdventOfCode2020.Day2.Challenge;

namespace AdventOfCode2020.Day2
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"First Challenge: {PasswordValidator.CountValidatePasswords(1)}");
            Console.WriteLine($"Second Challenge: {PasswordValidator.CountValidatePasswords(2)}");
        }
    }
}
