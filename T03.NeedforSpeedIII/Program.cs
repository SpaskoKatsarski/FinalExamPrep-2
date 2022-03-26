using System;
using System.Collections.Generic;

namespace T03.NeedforSpeedIII
{
    internal class Program
    {
        class Car
        {
            public Car(int mileage, int fuel)
            {
                this.Mileage = mileage;
                this.Fuel = fuel;
            }

            public int Mileage { get; set; }

            public int Fuel { get; set; }
        }

        static void Main(string[] args)
        {
            const int MaxFuel = 75;

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            //Adding cars to the dictionary:
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] carInfo = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars.Add(carName, new Car(mileage, fuel));
            }

            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                //  : 
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Drive")
                {
                    string carName = cmdArgs[1];
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (cars[carName].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distance;
                        cars[carName].Fuel -= fuel;
                        Console.WriteLine(
                            $"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (cars[carName].Mileage >= 100000)
                    {
                        cars.Remove(carName);
                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }
                else if (action == "Refuel")
                {
                    string carName = cmdArgs[1];
                    int fuel = int.Parse(cmdArgs[2]);

                    int addedFuel = fuel;

                    if (cars[carName].Fuel + fuel > 75)
                    {
                        // TODO: Fix the calculation
                        addedFuel = Math.Abs(MaxFuel - cars[carName].Fuel);
                        cars[carName].Fuel = MaxFuel;
                    }
                    else
                    {
                        cars[carName].Fuel += addedFuel;
                    }

                    Console.WriteLine($"{carName} refueled with {addedFuel} liters");
                }
                else if (action == "Revert")
                {
                    string carName = cmdArgs[1];
                    int kilometerDecrease = int.Parse(cmdArgs[2]);

                    if (cars[carName].Mileage - kilometerDecrease <= 10000)
                    {
                        cars[carName].Mileage = 10000;
                    }
                    else
                    {
                        cars[carName].Mileage -= kilometerDecrease;
                        Console.WriteLine($"{carName} mileage decreased by {kilometerDecrease} kilometers");
                    }
                }
            }

            foreach (KeyValuePair<string, Car> kvp in cars)
            {
                Console.WriteLine(
                    $"{kvp.Key} -> Mileage: {kvp.Value.Mileage} kms, Fuel in the tank: {kvp.Value.Fuel} lt.");
            }
        }
    }
}
