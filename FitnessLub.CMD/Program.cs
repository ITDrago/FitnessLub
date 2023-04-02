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
            Console.WriteLine();
            Console.Write("Enter the user gender: ");
            var gender = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter the user birth data: ");
            var birthData = DateTime.Parse(Console.ReadLine()); //TODO: To rewrite
            Console.WriteLine();
            Console.Write("Enter the user weight: ");
            var weight = Double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter the user height: ");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthData, weight, height);
            userController.Save();
        }

           
    }
}