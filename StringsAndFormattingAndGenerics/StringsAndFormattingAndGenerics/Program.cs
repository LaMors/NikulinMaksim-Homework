using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StringsAndFormattingAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void PrintOnlyNums(string stringWithNumbers)
        {
            var tempCharArray = stringWithNumbers.ToCharArray();

            foreach (var tempChar in tempCharArray)
            {
                if (char.IsDigit(tempChar))
                {
                    Console.WriteLine(tempChar);
                }
            }
        }

        public static void RoundToTwoNumbers(double firstNumber, double secondNumber)
        {
            var result = firstNumber / secondNumber;
            Console.WriteLine(Math.Round(result, 2));
        }

        public static void ExponentialNumberFromConsole()
        {
            Console.WriteLine("Enter an integer or exponential number");
            var result = Console.ReadLine();

            if (result.Contains('e'))
            {
                var splitResult = result.ToLower().Split('e');

                int mantissa;

                var mantissaIsReceived = int.TryParse(splitResult[0], out mantissa);

                int order;

                var orderIsReceived = int.TryParse(splitResult[0], out order);

                if (mantissaIsReceived && orderIsReceived)
                {
                    Console.WriteLine(mantissa * Math.Pow(10, order));
                }

                else
                {
                    Console.WriteLine("You entered incorrect data");
                }
            }

            else
            {
                int value;

                var valueIsReceived = int.TryParse(result, out value);

                Console.WriteLine(value.ToString("E"));
            }
        }

        public static void DataTimeToISO_8601()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd THH:mm:ss"));
        }

        public static void ToDataTime()
        {
            var tempString = "2016 21-07";

            tempString = tempString.Replace(' ', '-');

            var date = DateTime.ParseExact(tempString, "yyyy-dd-MM", CultureInfo.InvariantCulture);
            Console.WriteLine(date);
        }

        public static void SumOfNumbersInRow()
        {
            var tempString = Console.ReadLine();

            tempString = tempString.Remove(' ');

            var sumResult = default(int);

            foreach (var subString in tempString.Split(','))
            {
                sumResult += Convert.ToInt32(subString);
            }

            Console.WriteLine(sumResult);
        }

        public static void CapitalizeFirstLetter()
        {
            var NamesAndSurnames = new List<string>() { "иван иванов", "светлана иванова-петренко" };

            var NewNamesAndSurnames = new List<string>();

            foreach (var NamesAndSurname in NamesAndSurnames)
            {
                var result = Regex.Replace(NamesAndSurname, @"\b(\w)", m => m.Value.ToUpper());

                result = Regex.Replace(result, @"(\s(of|in|by|and)|\'[st])\b", m => m.Value.ToLower(), RegexOptions.IgnoreCase);

                NewNamesAndSurnames.Add(result);
            }

            foreach (var NamesAndSurname in NewNamesAndSurnames)
            {
                Console.WriteLine(NamesAndSurname);
            }
        }

        public static void Base64Decoder()
        {
            var base64String = "0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C / 0L7Qu9C90LXQvdC + INCy0LXRgNC90L4gOik =";

            var base64 = Convert.FromBase64String(base64String);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(base64));
        }
    }
}
