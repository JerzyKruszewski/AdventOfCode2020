﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day7.Challenge
{
    public class LuggageParser
    {
        private static string PreParseBagEntry(string entry)
        {
            return entry.Replace(".", "").Replace("bags", "bag").Replace("bag", "").Replace("contain", ",");
        }

        public static string[] ParseBagEntry(string entry)
        {
            return PreParseBagEntry(entry).Split(", ");
        }

        public static string RemoveNumbers(string arg)
        {
            return arg.Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "")
                .Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "");
        }
    }
}
