using NUnit.Framework;
using System.Collections.Generic;
using AdventOfCode2020.Day10.Challenge;
using System.Linq;

namespace Day10.Tests
{
    public class AdaptersHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OneJoltDifferencesMultipliedByThreeJoltDiff_WhenCalledWithExampleValues_Return220()
        {
            List<int> param = new List<int>()
            {
                28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35,
                8, 17, 7, 9, 4, 2, 34, 10, 3
            };

            Assert.AreEqual(220, AdaptersHandler.OneJoltDifferencesMultipliedByThreeJoltDiff(0, param));
        }

        [Test]
        public void FindQuantityOfDifferentAdapterCombinations_WhenCalledWithExampleValues_Return8()
        {
            List<int> param = new List<int>()
            {
                16,10,15,5,1,11,7,19,6,12,4
            };

            Assert.AreEqual(8, AdaptersHandler.FindQuantityOfDifferentAdapterCombinations(param));
        }

        [Test]
        public void FindQuantityOfDifferentAdapterCombinations_WhenCalledWithExampleValues_Return19208()
        {
            List<int> param = new List<int>()
            {
                28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35,
                8, 17, 7, 9, 4, 2, 34, 10, 3
            };

            Assert.AreEqual(19208, AdaptersHandler.FindQuantityOfDifferentAdapterCombinations(param));
        }

        [Test]
        public void FindQuantityOfDifferentAdapterCombinations_WhenCalledWithDefaultInput_GetsAllPossibleAdapterConnections()
        {
            Assert.AreEqual(386869246296064, AdaptersHandler.FindQuantityOfDifferentAdapterCombinations());
        }
    }
}