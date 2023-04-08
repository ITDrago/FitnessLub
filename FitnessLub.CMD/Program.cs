using System;
using FitnessLub.BL.Controller;
using FitnessLub.BL.Model;

namespace FitnessLub.CMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome FitnessLub!");
            Console.WriteLine();
            Console.Write("Enter the user name: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter the gender: ");
                var gender = Console.ReadLine();
                DateTime birthData = ParseDataTime("birthData");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthData, weight, height);
            }
            Console.WriteLine();
            Console.WriteLine("E - Enter a meal");
            Console.WriteLine();
            Console.Write("What do you want to do: ");
            
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                Console.WriteLine("You ate today:        ");
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");  
                }

            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine();
            Console.Write("Enter the product name: ");
            var food = Console.ReadLine();

            var colories = ParseDouble("calories");
            var prot = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var weight = ParseDouble("weight of the portion");
            var product = new Food(food,colories,prot,fats,carbohydrates);
            return (Food: product, Weight: weight);
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