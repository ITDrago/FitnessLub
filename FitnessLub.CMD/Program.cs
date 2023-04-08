using System;
using System.Globalization;
using FitnessLub.BL.Controller;
using FitnessLub.BL.Model;
using System.Resources;

namespace FitnessLub.CMD;

public class Program
{
    public static  ResourceManager resourceManager = new ResourceManager("FitnessLub.CMD.Languages.Messages", typeof(Program).Assembly);
    static void Main(string[] args)
    {
        var userChoice = GetUserLanguage();
        if (userChoice)
        {
        var culture = CultureInfo.CreateSpecificCulture("ru-ru");
        }
        Console.WriteLine("\n");
        Console.WriteLine(resourceManager.GetString("Welcome"));
        Console.WriteLine();
        Console.Write(resourceManager.GetString("UserName"));
        var name = Console.ReadLine();
        var userController = new UserController(name);
        var eatingController = new EatingController(userController.CurrentUser);
        if (userController.IsNewUser)
        {
            Console.Write(resourceManager.GetString("EnterGender"));
            var gender = Console.ReadLine();
            DateTime birthData = ParseDataTime(resourceManager.GetString("BirthData"));
            double weight = ParseDouble(resourceManager.GetString("Weight"));
            double height = ParseDouble(resourceManager.GetString("Height"));

            userController.SetNewUserData(gender, birthData, weight, height);
        }
        Console.WriteLine();
        Console.WriteLine($"E - {resourceManager.GetString("EnterMeal")}");
        Console.WriteLine();
        Console.Write($"{resourceManager.GetString("WhatDo")}: ");
        
        var key = Console.ReadKey();

        if(key.Key == ConsoleKey.E)
        {
            var foods = EnterEating();
            eatingController.Add(foods.Food, foods.Weight);
            Console.WriteLine($"{resourceManager.GetString("YouAte")}:        ");
            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");  
            }

        }
    }

    private static (Food Food, double Weight) EnterEating()
    {
        Console.WriteLine();
        Console.Write($"{resourceManager.GetString("EnterTheProductName")}: ");
        var food = Console.ReadLine();

        var colories = ParseDouble(resourceManager.GetString("Calories"));
        var prot = ParseDouble(resourceManager.GetString("Proteins"));
        var fats = ParseDouble(resourceManager.GetString("Fats"));
        var carbohydrates = ParseDouble(resourceManager.GetString("Carbohydrates"));
        var weight = ParseDouble(resourceManager.GetString("WeightOf"));
        var product = new Food(food,colories,prot,fats,carbohydrates);
        return (Food: product, Weight: weight);
    }

    private static double ParseDouble(string name)
    {
        while (true)
        {
            Console.Write($"{resourceManager.GetString("EnterThe")} {name}: ");
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
            Console.Write($"{resourceManager.GetString("EnterThe")} {name} (dd.MM.yyyy): ");
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
    public static  bool GetUserLanguage()
    {
        Console.WriteLine();
        Console.WriteLine("Default language: English");
        Console.Write("Change the language tu Russian? (Y/N): ");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        if (key.Key == ConsoleKey.N)
            return false;
        throw new AggregateException("Incorrect data");
    }

        
}        
