using System;
using System.Collections.Generic;

namespace T03._P_rates
{
    class City
    {
        public City(int population, int gold)
        {
            this.Population = population;
            this.Gold = gold;
        }

        public int Population { get; set; }

        public int Gold { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cityInfo = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities.Add(cityName, new City(0, 0));
                }

                cities[cityName].Population += population;
                cities[cityName].Gold += gold;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                string cityName = cmdArgs[1];

                if (action == "Plunder")
                {
                    int peopleKilled = int.Parse(cmdArgs[2]);
                    int goldStolen = int.Parse(cmdArgs[3]);

                    cities[cityName].Population -= peopleKilled;
                    cities[cityName].Gold -= goldStolen;

                    Console.WriteLine($"{cityName} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                    if (IsCityDead(cities, cityName))
                    {
                        cities.Remove(cityName);
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int goldToAdd = int.Parse(cmdArgs[2]);

                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[cityName].Gold += goldToAdd;

                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {cityName} now has {cities[cityName].Gold} gold.");
                    }
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (KeyValuePair<string, City> city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        static bool IsCityDead(Dictionary<string, City> cities, string cityName)
        {
            if (cities[cityName].Population <= 0 || cities[cityName].Gold <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
