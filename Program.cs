﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark

{

    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

    }


    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("****************************************");
            Console.WriteLine("    Welcome to Jurassic Park   ");
            Console.WriteLine("****************************************");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                 ...Life uh, finds a way.");
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var dinosaurs = new List<Dinosaur>();



            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\n(A)dd a dinosaur\n(F)ind a dinosaur\n(S)how all the dinosaurs\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    keepGoing = false;

                }
                else
                if (choice == "F")
                {

                    var nameToSearchFor = PromptForString("What dinosaur are you looking for? ");

                    Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearchFor);


                    if (foundDinosaur == null)
                    {
                        Console.WriteLine(" Access Denied ...haha! -DN");
                    }
                    else
                    {
                        Console.WriteLine($"Your Dino DNA says, {foundDinosaur.Name} is a {foundDinosaur.DietType} and is in enclosure: {foundDinosaur.EnclosureNumber}.");
                    }







                }
                else
                if (choice == "S")
                {
                    foreach (var dinosaur in dinosaurs)
                    {
                        Console.WriteLine($"Your Dino DNA says, {dinosaur.Name} is a {dinosaur.DietType} and is in enclosure: {dinosaur.EnclosureNumber}.");
                    }
                }
                else

                {

                    var dinosaur = new Dinosaur();

                    dinosaur.Name = PromptForString("What is the name of the dinosaur? ");
                    dinosaur.DietType = PromptForString("Is it a (C)arnivore or a (H)erbivore? ").ToUpper();
                    dinosaur.WhenAcquired = DateTime.Now;
                    dinosaur.Weight = PromptForInteger("How much does the dino weigh, in pounds? ");
                    dinosaur.EnclosureNumber = PromptForInteger("Please assign this dino to an enclosure number: ");

                    dinosaurs.Add(dinosaur);

                }


            }








        }
    }
}