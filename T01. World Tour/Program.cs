using System;

namespace T01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string trafficPlan = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (IsIndexValid(trafficPlan, index))
                    {
                        string value = cmdArgs[2];
                        trafficPlan = trafficPlan.Insert(index, value);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if (IsIndexValid(trafficPlan, startIndex) || !IsIndexValid(trafficPlan, endIndex) && (IsIndexValid(trafficPlan, startIndex + 1) && IsIndexValid(trafficPlan, endIndex + 1)))
                    {
                        if (IsIndexValid(trafficPlan, endIndex))
                        {
                            trafficPlan = trafficPlan.Remove(startIndex, endIndex - startIndex + 1);
                        }
                    }
                }
                else if (action == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];

                    if (IsContainingString(trafficPlan, oldString))
                    {
                        trafficPlan = trafficPlan.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(trafficPlan);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {trafficPlan}");
        }

        static bool IsIndexValid(string str, int index)
        {
            return index >= 0 && index < str.Length;
        }

        static bool IsContainingString(string str, string value)
        {
            return str.Contains(value);
        }
    }
}
