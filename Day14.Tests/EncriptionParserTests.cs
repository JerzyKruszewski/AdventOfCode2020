using AdventOfCode2020.Day14.Challenge;
using NUnit.Framework;

namespace Day14.Tests
{
    public class EncriptionParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("0", "000000000000000000000000000000000000")]
        [TestCase("1", "000000000000000000000000000000000001")]
        [TestCase("64", "000000000000000000000000000001000000")]
        [TestCase("73", "000000000000000000000000000001001001")]
        [TestCase("101", "000000000000000000000000000001100101")]
        public void ConvertBitsToDecimalString_WhenCalled_ReturnNumberInDecimal(string expected, string bits)
        {
            Assert.AreEqual(expected, EncriptionParser.ConvertBitsToDecimalString(bits));
        }

        [Test]
        [TestCase("000000000000000000000000000000000000", "0")]
        [TestCase("000000000000000000000000000000000001", "1")]
        [TestCase("000000000000000000000000000001000000", "64")]
        [TestCase("000000000000000000000000000001001001", "73")]
        [TestCase("000000000000000000000000000001100101", "101")]
        public void ConvertDecimalToBitsString_WhenCalled_ReturnNumberInDecimal(string expected, string deciText)
        {
            Assert.AreEqual(expected, EncriptionParser.ConvertDecimalToBitsString(deciText));
        }

        [Test]
        [TestCase(9, @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0")]
        [TestCase(65215, @"mask = X10110101011011100X01X01101101000X01
mem[55980] = 134072224
mem[4807] = 6332
mem[23989] = 1457360
mem[16588] = 1148127
mem[65214] = 634126
mem[56601] = 198043
mem[1770] = 860")]
        public void GetMemoryLenght_WhenCalled_ReturnMemoryLenght(int expected, string input)
        {
            Assert.AreEqual(expected, EncriptionParser.GetMemoryLenght(input.Split("\r\n")));
        }

        [Test]
        [TestCase("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [TestCase("X10110101011011100X01X01101101000X01", @"mask = X10110101011011100X01X01101101000X01")]
        public void GetMemoryMask_WhenCalled_ReturnMemoryMask(string expected, string line)
        {
            Assert.AreEqual(expected, EncriptionParser.GetMemoryMask(line));
        }
    }
}