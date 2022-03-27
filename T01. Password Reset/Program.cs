using System;
using System.Linq;

namespace T01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "TakeOdd")
                {
                    password = string.Join("", password.Where((x, index) => index % 2 != 0));
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);

                    password = password.Remove(index, length);
                }
                else if (action == "Substitute")
                {
                    string strToReplace = cmdArgs[1];
                    string substitute = cmdArgs[2];

                    if (!password.Contains(strToReplace))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }

                    password = password.Replace(strToReplace, substitute);
                }

                Console.WriteLine(password);
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
