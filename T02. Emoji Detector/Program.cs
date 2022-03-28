using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace T02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string emojiPattern = @"(?<border>\:\:|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            string numberPattern = @"\d";

            string input = Console.ReadLine();

            Regex regex = new Regex(emojiPattern);
            MatchCollection validEmojis = regex.Matches(input);

            MatchCollection numbers = Regex.Matches(input, numberPattern);

            BigInteger coolThreshold = 1;
            foreach (Match number in numbers)
            {
                coolThreshold *= int.Parse(number.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            // We have the cool threshold and now we have to check which emojis we should keep and then print.

            Dictionary<string, string> coolEmojis = new Dictionary<string, string>();

            int foundEmojisCount = 0;
            foreach (Match emoji in validEmojis)
            {
                string currEmoji = emoji.Groups["emoji"].Value;
                int currSum = 0;

                foreach (char ch in currEmoji)
                {
                    currSum += ch;
                }

                if (currSum > coolThreshold)
                {
                    coolEmojis.Add(currEmoji, emoji.Groups["border"].Value);
                }

                foundEmojisCount++;
            }

            Console.WriteLine($"{foundEmojisCount} emojis found in the text. The cool ones are:");
            foreach (KeyValuePair<string, string> emoji in coolEmojis)
            {
                Console.WriteLine($"{emoji.Value}{emoji.Key}{emoji.Value}");
            }
        }
    }
}
