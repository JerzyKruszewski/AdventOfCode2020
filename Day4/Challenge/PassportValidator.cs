using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day4.Challenge
{
    public class PassportValidator
    {
        private static readonly IList<string> _passports;

        static PassportValidator()
        {
            string content;

            using (StreamReader reader = new StreamReader("./Challenge/input.txt", Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }

            _passports = content.Split("\r\n\r\n").ToList();
        }

        public static int CountValidatedPassports(int noOfChallenge)
        {
            int validated = 0;

            foreach (string passport in _passports)
            {
                if (ValidatePassports(passport))
                {
                    if (noOfChallenge == 1)
                    {
                        validated++;
                    }
                    else if (noOfChallenge == 2)
                    {
                        if (AdditionalValidation(ParseValues(PreParseValues(passport))))
                        {
                            validated++;
                        }
                    }
                }
            }

            return validated;
        }

        public static bool ValidateOnePassport(string passport)
        {
            return (ValidatePassports(passport) && AdditionalValidation(ParseValues(PreParseValues(passport))));
        }

        private static bool ValidatePassports(string passport)
        {
            return (passport.Contains("byr:") && passport.Contains("iyr:") &&
                passport.Contains("eyr:") && passport.Contains("hgt:") && passport.Contains("hcl:") &&
                passport.Contains("ecl:") && passport.Contains("pid:"));
        }

        private static string[] PreParseValues(string passport)
        {
            return passport.Replace("\r\n", " ").Replace("\n", " ").Split(' ');
        }

        private static Dictionary<string, string> ParseValues(string[] passport)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (string item in passport)
            {
                string[] keyValuePair = item.Split(':');
                keyValuePairs.Add(keyValuePair[0], keyValuePair[1]);
            }

            return keyValuePairs;
        }

        private static bool AdditionalValidation(Dictionary<string, string> passportValues)
        {
            List<bool> validations = new List<bool>();

            foreach (KeyValuePair<string, string> pair in passportValues)
            {
                switch (pair.Key)
                {
                    case "byr":
                        validations.Add(ValidateYear(pair.Value, 1920, 2002));
                        break;
                    case "iyr":
                        validations.Add(ValidateYear(pair.Value, 2010, 2020));
                        break;
                    case "eyr":
                        validations.Add(ValidateYear(pair.Value, 2020, 2030));
                        break;
                    case "hgt":
                        validations.Add(ValidateHeight(pair.Value, 150, 193, 59, 76));
                        break;
                    case "hcl":
                        validations.Add(ValidateHairColor(pair.Value));
                        break;
                    case "ecl":
                        validations.Add(ValidateEyeColor(pair.Value));
                        break;
                    case "pid":
                        validations.Add(ValidatePassportId(pair.Value));
                        break;
                    default:
                        break;
                }
            }

            return validations.All(v => v);
        }

        private static bool ValidateYear(string yearText, int min, int max)
        {
            if (string.IsNullOrEmpty(yearText))
            {
                return false;
            }

            try
            {
                int year = int.Parse(yearText);

                return (year >= min && year <= max);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ValidateHeight(string heightText, int cmMin, int cmMax, int inMin, int inMax)
        {
            if (string.IsNullOrEmpty(heightText))
            {
                return false;
            }

            int height;

            try
            {
                if (heightText.Contains("cm"))
                {
                    height = int.Parse(heightText.Replace("cm", ""));

                    return (height >= cmMin && height <= cmMax);
                }

                if (heightText.Contains("in"))
                {
                    height = int.Parse(heightText.Replace("in", ""));

                    return (height >= inMin && height <= inMax);
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ValidateHairColor(string value)
        {
            if (!value.StartsWith("#") || value.Length != 7 || string.IsNullOrEmpty(value))
            {
                return false;
            }

            string validCharacters = "0123456789abcdef";

            value = value.Remove(0, 1);

            foreach (char character in value)
            {
                if (!validCharacters.Contains(character))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateEyeColor(string value)
        {
            return value switch
            {
                "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth" => true,
                _ => false,
            };
        }

        private static bool ValidatePassportId(string value)
        {
            if (value.Length != 9)
            {
                return false;
            }

            try
            {
                int.Parse(value);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //FOR TESTING PURPOSES
        public static bool TValidateYear(string yearText, int min, int max)
        {
            return ValidateYear(yearText, min, max);
        }

        public static bool TValidateHeight(string heightText, int cmMin, int cmMax, int inMin, int inMax)
        {
            return ValidateHeight(heightText, cmMin, cmMax, inMin, inMax);
        }

        public static bool TValidateHairColor(string value)
        {
            return ValidateHairColor(value);
        }

        public static bool TValidateEyeColor(string value)
        {
            return ValidateEyeColor(value);
        }

        public static bool TValidatePassportId(string value)
        {
            return ValidatePassportId(value);
        }

        public static string[] TPreParseValues(string passport)
        {
            return PreParseValues(passport);
        }
    }
}
