using System;
using System.Linq;

namespace T._01SecretChar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);
                    message = message.Insert(index, " ");
                }
                else if (action == "Reverse")
                {
                    string subStr = cmdArgs[1];

                    if (!message.Contains(subStr))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    int index = message.IndexOf(subStr);
                    message = message.Remove(index, subStr.Length);

                    string reversedMessage = string.Join("", subStr.Reverse());

                    message = message.Insert(message.Length, reversedMessage);
                }
                else if (action == "ChangeAll")
                {
                    string strToReplace = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    message = message.Replace(strToReplace, replacement);
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
