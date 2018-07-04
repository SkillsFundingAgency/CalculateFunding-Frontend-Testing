using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Frontend.IntegrationTests.Helpers
{
    class TestDataUtils
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

    class TestDataNumericUtils
    {
        private static Random random = new Random();
        public static string RandomNumerics(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

    class TestDataAlphaUtils
    {
        private static Random random = new Random();
        public static string RandomAlphas(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

    class TestRegexUtil

    {
        public static bool NumbersEqual(string exampleString)
        {
            Regex regex = new Regex(@"([\d]+)\/([\d]+)");

            if (regex.IsMatch(exampleString))
            {
                string[] matches = regex.Split(exampleString);

                string firstNumber = matches[1];
                string secondNumber = matches[2];

                if (firstNumber == secondNumber)
                {
                    Console.WriteLine("The numbers are the same");
                    return true;
                }


            }
            return false;
        }
    }
}
    


