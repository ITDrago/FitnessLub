using System;
using FitnessLub.BL.Controller;

namespace FitnessLub.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome FitnessLub!");
            Console.WriteLine();
            Console.Write("Enter the user name: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter the gender: ");
                var gender = Console.ReadLine();
                DateTime birthData = ParseDataTime("birthData");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthData, weight, height);
            }
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect format for {name}");
                }
            }
        }

        private static DateTime ParseDataTime(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect format for {name}");
                }
            }
        }
    }        
}