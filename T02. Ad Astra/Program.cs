using System;
using System.Text.RegularExpressions;

namespace T02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DailyCalories = 2000;

            string pattern = @"(\#|\|)(?<food>[A-Za-z ]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

            string input = Console.ReadLine();

            MatchCollection food = Regex.Matches(input, pattern);

            int totalCalories = 0;

            foreach (Match match in food)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int survivedDays = totalCalories / DailyCalories;

            Console.WriteLine($"You have food to last you for: {survivedDays} days!");
            foreach (Match match in food)
            {
                Console.WriteLine($"Item: {match.Groups["food"]}, Best before: {match.Groups["date"]}, Nutrition: {match.Groups["calories"]}");
            }
        }
    }
}
