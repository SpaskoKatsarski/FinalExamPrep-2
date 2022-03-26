using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\@|\#)(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();

            StringBuilder mirroredWords = new StringBuilder();
            MatchCollection matches = Regex.Matches(input, pattern);

            int matchedWordsCount = 0;

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["wordOne"].Value;
                string secondWord = match.Groups["wordTwo"].Value;

                if (firstWord == string.Join("", secondWord.Reverse()))
                {
                    //{wordOne} <=> {wordtwo}, {wordOne} <=> {wordtwo}, …
                    mirroredWords.Append($"{firstWord} <=> {secondWord}, ");
                }

                matchedWordsCount++;
            }

            if (matchedWordsCount > 0)
            {
                Console.WriteLine($"{matchedWordsCount} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            int index = mirroredWords.ToString().LastIndexOf(", ");

            if (index != -1)
            {
                string result = mirroredWords.ToString().Remove(index, 2);


                Console.WriteLine("The mirror words are:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
