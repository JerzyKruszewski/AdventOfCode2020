using AdventOfCode2020.Day14.Challenge;
using NUnit.Framework;
using System.Collections.Generic;

namespace Day14.Tests
{
    public class EncriptionHandlerTests
    {
        [Test]
        [TestCase(new string[4] 
        {
            "000000000000000000000000000000011010",
            "000000000000000000000000000000011011",
            "000000000000000000000000000000111010",
            "000000000000000000000000000000111011"
        }, @"000000000000000000000000000000X1101X")]
        public void MakeBitPermutations_WhenCalled_ReturnsBitPermutations(string[] expected, string line)
        {
            Assert.AreEqual(expected, new EncriptionHandler(2).MakeBitPermutations(line).ToArray());
        }

        //[Test]
        //[TestCase(208, new string[2]
        //{
        //    "000000000000000000000000000000X1101X",
        //    "00000000000000000000000000000001X0XX"
        //})]
        //public void GetSumOfMemoryValues_WhenCalled_ReturnsAnswer(long expected, string[] memory)
        //{
        //    Assert.AreEqual(expected, new EncriptionHandler(2).GetSumOfMemoryValues(memory));
        //}
    }
}
