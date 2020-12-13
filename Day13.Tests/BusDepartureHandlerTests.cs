using AdventOfCode2020.Day13.Challenge;
using NUnit.Framework;

namespace Day13.Tests
{
    public class BusDepartureHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNextBusIdMultipliedByWaitTime_WhenCalledWithoutValues_ReturnChallengeResult()
        {
            Assert.AreEqual(6559, new BusDepartureHandler(1).GetNextBusIdMultipliedByWaitTime());
        }

        [Test]
        [TestCase(3417L, "17,x,13,19")]
        [TestCase(754018L, "67,7,59,61")]
        [TestCase(779210L, "67,x,7,59,61")]
        [TestCase(1261476L, "67,7,x,59,61")]
        [TestCase(1202161486L, "1789,37,47,1889")]
        [TestCase(1068781L, "7,13,x,x,59,x,31,19")]
        public void GetEarliestDepartureFromPart2_WhenCalled_ReturnEarliestDeparture(long expected, string busses)
        {
            Assert.AreEqual(expected, new BusDepartureHandler(2).GetEarliestDepartureFromPart2(busses));
        }

        [Test]
        [TestCase(3417L, "17,x,13,19")]
        [TestCase(754018L, "67,7,59,61")]
        [TestCase(779210L, "67,x,7,59,61")]
        [TestCase(1261476L, "67,7,x,59,61")]
        [TestCase(1202161486L, "1789,37,47,1889")]
        [TestCase(1068781L, "7,13,x,x,59,x,31,19")]
        [TestCase(626670513163231L, "")]
        public void FindEarliestTimestamp_WhenCalled_ReturnTimestampOfEarliestDeparture(long expected, string busses)
        {
            Assert.AreEqual(expected, new BusDepartureHandler(2).FindEarliestTimestamp(busses));
        }
    }
}