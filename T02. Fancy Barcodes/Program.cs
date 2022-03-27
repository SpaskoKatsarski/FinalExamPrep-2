using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace T02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^@[#]{1,}(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@[#]{1,}$";

            Regex barcodeValidator = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match currentBarcodeMatch = barcodeValidator.Match(input);

                if (!currentBarcodeMatch.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string productName = currentBarcodeMatch.Groups["product"].Value;

                    StringBuilder productGroup = GetProductGroup(productName);

                    Console.WriteLine($"Product group: {productGroup}");
                }
            }
        }

        // Make a method that gets the product group.
        static StringBuilder GetProductGroup(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    sb.Append(ch);
                }
            }

            if (!sb.ToString().Any())
            {
                StringBuilder result = new StringBuilder("00");
                return result;
            }

            return sb;
        }
    }
}
