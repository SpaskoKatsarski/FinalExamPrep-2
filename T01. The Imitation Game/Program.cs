using System;

namespace T01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Move")
                {
                    int numberOfLetters = int.Parse(cmdArgs[1]);

                    string subStr = message.Substring(0, numberOfLetters);
                    message = message.Remove(0, numberOfLetters);
                    message = message.Insert(message.Length, subStr);
                }
                else if (action == "Insert")
                {
                    int indexToInsert = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    message = message.Insert(indexToInsert, value);
                }
                else if (action == "ChangeAll")
                {
                    string strToChange = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    message = message.Replace(strToChange, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
