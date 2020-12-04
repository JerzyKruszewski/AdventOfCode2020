using NUnit.Framework;

namespace Day4.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(true, @"pid:214212776 hcl:#18171d
eyr:2030
iyr:2020 byr:1988
cid:122
hgt:170cm ecl:oth")]
        public void ValidateOnePassport_WhenCalled_CheckIfPassportIsValid(bool expected, string passport)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.ValidateOnePassport(passport));
        }

        [Test]
        [TestCase(true, @"1988", 1920, 2002)]//byr:
        [TestCase(true, @"2020", 2010, 2020)]//iyr:
        [TestCase(true, @"2030", 2020, 2030)]//eyr:
        public void TValidateYear_WhenCalled_CheckIfYearIsValid(bool expected, string year, int min, int max)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TValidateYear(year, min, max));
        }

        [Test]
        [TestCase(true, @"170cm", 150, 193, 59, 76)]
        public void TValidateHeight_WhenCalled_CheckIfHeightIsValid(bool expected, string height, int cmMin, int cmMax, int inMin, int inMax)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TValidateHeight(height, cmMin, cmMax, inMin, inMax));
        }

        [Test]
        [TestCase(true, @"#18171d")]
        public void TValidateHairColor_WhenCalled_CheckIfHairColorIsValid(bool expected, string passport)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TValidateHairColor(passport));
        }

        [Test]
        [TestCase(true, @"oth")]
        public void TValidateEyeColor_WhenCalled_CheckIfEyeColorIsValid(bool expected, string passport)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TValidateEyeColor(passport));
        }

        [Test]
        [TestCase(true, @"214212776")]
        public void TValidatePassportId_WhenCalled_CheckIfPassportIdIsValid(bool expected, string passport)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TValidatePassportId(passport));
        }

        [TestCase(new string[] { "pid:214212776", "hcl:#18171d", "eyr:2030", "iyr:2020", "byr:1988", "cid:122", "hgt:170cm", "ecl:oth" },
            @"pid:214212776 hcl:#18171d
eyr:2030
iyr:2020 byr:1988
cid:122
hgt:170cm ecl:oth")]
        public void TPreParseValues_WhenCalled_ReturnPreparseValues(string[] expected, string passport)
        {
            Assert.AreEqual(expected, AdventOfCode2020.Day4.Challenge.PassportValidator.TPreParseValues(passport));
        }
    }
}