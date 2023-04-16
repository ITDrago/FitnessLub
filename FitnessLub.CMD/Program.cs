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
        var exerciseController = new ExerciseController(userController.CurrentUser);
        if (userController.IsNewUser)
        {
            Console.Write(resourceManager.GetString("EnterGender"));
            var gender = Console.ReadLine();
            DateTime birthData = ParseDataTime(resourceManager.GetString("BirthData", culture),"(dd.MM.yyyy)");
            double weight = ParseDouble(resourceManager.GetString("Weight",culture));
            double height = ParseDouble(resourceManager.GetString("Height",culture));

            userController.SetNewUserData(gender, birthData, weight, height);
        }
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"E - {resourceManager.GetString("EnterMeal", culture)}");
            Console.WriteLine($"A - {resourceManager.GetString("EnterTheExercise", culture)}");
            Console.WriteLine($"Q - {resourceManager.GetString("ExitProgram", culture)}");
            Console.Write($"{resourceManager.GetString("WhatDo", culture)}: ");
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);
                    Console.WriteLine($"{resourceManager.GetString("YouAte",culture)}:        ");
                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{item.Key} - {item.Value}");  
                    }
                    break;
                case ConsoleKey.A:
                    var exe = EnterExercise();
                    exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                    Console.WriteLine($"{resourceManager.GetString("YourExercise", culture)}:        ");
                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine($"\t{item.Activity} : {item.Start.ToShortTimeString()} - {item.Finish.ToShortTimeString()}");
                    }
                    break;

                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
    {
        Console.WriteLine();
        Console.Write(resourceManager.GetString("EnterExerciseName",culture));
        var name = Console.ReadLine();
        var energy = ParseDouble(resourceManager.GetString("Energy", culture));
        var begin = ParseDataTime(resourceManager.GetString("Begin", culture), "(hh:mm)");
        var end = ParseDataTime(resourceManager.GetString("End", culture), "(hh:mm)");
        var activity = new Activity(name, energy);
        return(begin, end, activity);
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

    private static DateTime ParseDataTime(string name,string format)
    {
        while (true)
        {
            Console.Write($"{resourceManager.GetString("EnterThe",culture)} {name} {format}: ");
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
        Console.Write("Change the language to Russian? (Y/N): ");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        if (key.Key == ConsoleKey.N)
            return false;
        throw new AggregateException("Incorrect data");
    }

        
}        
