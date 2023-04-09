using System;
using System.Globalization;
using FitnessLub.BL.Controller;
using FitnessLub.BL.Model;
using System.Resources;

namespace FitnessLub.CMD;

public class Program
{
    public static  ResourceManager resourceManager = new ResourceManager("FitnessLub.CMD.Languages.Messages", typeof(Program).Assembly);
    public static System.Globalization.CultureInfo culture;
    static void Main(string[] args)
    {
        var userChoice = GetUserLanguage();
        
        if (userChoice)
        {
             culture = CultureInfo.CreateSpecificCulture("ru-ru");
        }

        else
        {
             culture = CultureInfo.CreateSpecificCulture("en-us");
        }
        

        
        
        
        Console.WriteLine("\n");
        Console.WriteLine(resourceManager.GetString("Welcome",culture));
        Console.WriteLine();
        Console.Write(resourceManager.GetString("UserName",culture));
        var name = Console.ReadLine();
        var userController = new UserController(name);
        var eatingController = new EatingController(userController.CurrentUser);
        if (userController.IsNewUser)
        {
            Console.Write(resourceManager.GetString("EnterGender"));
            var gender = Console.ReadLine();
            DateTime birthData = ParseDataTime(resourceManager.GetString("BirthData", culture));
            double weight = ParseDouble(resourceManager.GetString("Weight",culture));
            double height = ParseDouble(resourceManager.GetString("Height",culture));

            userController.SetNewUserData(gender, birthData, weight, height);
        }
        Console.WriteLine();
        Console.WriteLine($"E - {resourceManager.GetString("EnterMeal",culture)}");
        Console.WriteLine();
        Console.Write($"{resourceManager.GetString("WhatDo",culture)}: ");
        
        var key = Console.ReadKey();

        if(key.Key == ConsoleKey.E)
        {
            var foods = EnterEating();
            eatingController.Add(foods.Food, foods.Weight);
            Console.WriteLine($"{resourceManager.GetString("YouAte",culture)}:        ");
            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");  
            }

        }
    }

    private static (Food Food, double Weight) EnterEating()
    {
        Console.WriteLine();
        Console.Write($"{resourceManager.GetString("EnterTheProductName",culture)}: ");
        var food = Console.ReadLine();

        var colories = ParseDouble(resourceManager.GetString("Calories",culture));
        var prot = ParseDouble(resourceManager.GetString("Proteins",culture));
        var fats = ParseDouble(resourceManager.GetString("Fats",culture));
        var carbohydrates = ParseDouble(resourceManager.GetString("Carbohydrates",culture));
        var weight = ParseDouble(resourceManager.GetString("WeightOf",culture));
        var product = new Food(food,colories,prot,fats,carbohydrates);
        return (Food: product, Weight: weight);
    }

    private static double ParseDouble(string name)
    {
        while (true)
        {
            Console.Write($"{resourceManager.GetString("EnterThe",culture)} {name}: ");
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
            Console.Write($"{resourceManager.GetString("EnterThe",culture)} {name} (dd.MM.yyyy): ");
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
    public static bool GetUserLanguage()
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
