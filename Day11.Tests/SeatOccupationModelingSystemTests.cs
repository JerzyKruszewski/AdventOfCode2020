using NUnit.Framework;

namespace Day11.Tests
{
    public class SeatOccupationModelingSystemTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Iterate_WhenCalledWithExampleValuesFromPartOne_PerformOneIterationOfCellularAutomata()
        {
            string param = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            string expected = @"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##";

            Assert.AreEqual(expected, AdventOfCode2020.Day11.Challenge.SeatOccupationModelingSystem.Iterate(0, 4, 1, param));
        }

        [Test]
        public void Iterate_WhenCalledWithExampleValuesFromPartTwo_PerformOneIterationOfCellularAutomata()
        {
            string param = @"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##";

            string expected = @"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#";

            Assert.AreEqual(expected, AdventOfCode2020.Day11.Challenge.SeatOccupationModelingSystem.Iterate(0, 5, 2, param));
        }
    }
}