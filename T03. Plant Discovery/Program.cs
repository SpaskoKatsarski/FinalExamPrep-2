using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Plant_Discovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = new List<double>();
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; }

        public void AddRating(double rating)
        {
            this.Rating.Add(rating);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantsInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantName = plantsInfo[0];
                int plantRarity = int.Parse(plantsInfo[1]);

                if (DoesContainPlant(plants, plantName))
                {
                    Plant currentPlant = GetPlantByName(plants, plantName);

                    if (currentPlant != null)
                    {
                        currentPlant.Rarity = plantRarity;
                    }
                }
                else
                {
                    plants.Add(new Plant(plantName, plantRarity));
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = input
                    .Split(new[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];
                string plantName = cmdArgs[1];

                if (action == "Rate")
                {
                    if (!DoesContainPlant(plants, plantName))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        double currRating = double.Parse(cmdArgs[2]);
                        Plant currentPlant = GetPlantByName(plants, plantName);

                        currentPlant.AddRating(currRating);
                    }
                }
                else if (action == "Update")
                {
                    if (!DoesContainPlant(plants, plantName))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        int updateRarity = int.Parse(cmdArgs[2]);

                        Plant currPlant = GetPlantByName(plants, plantName);
                        currPlant.Rarity = updateRarity;
                    }
                }
                else if (action == "Reset")
                {
                    // Add validation
                    if (!DoesContainPlant(plants, plantName))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Plant currPlant = GetPlantByName(plants, plantName);

                        currPlant.Rating.Clear();
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant plant in plants)
            {
                double averageRating = 0;

                if (plant.Rating.Count > 0)
                {
                    averageRating = plant.Rating.Average();
                }

                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {averageRating:f2}");
            }
            // Solved 100/100
        }
        
        static bool DoesContainPlant(List<Plant> allPlants, string plant)
        {
            return allPlants.Any(x => x.Name == plant);
        }

        static Plant GetPlantByName(List<Plant> allPlants, string plantName)
        {
            Plant currentPlant = allPlants.FirstOrDefault(x => x.Name == plantName);
            return currentPlant;
        }
    }
}
