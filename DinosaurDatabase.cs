using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace JurassicPark

{
    class DinosaurDatabase
    {

        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddDinosaur(Dinosaur add)
        {
            Dinosaurs.Add(add);
        }

        public List<Dinosaur> GetAllDinosaurs()
        {
            return Dinosaurs;
        }

        public Dinosaur ViewOneDinosaur(string nameToFind)
        {
            Dinosaur foundDinosaur = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundDinosaur;
        }

        public void RemoveDinosaur(Dinosaur dinosaurToRemove)
        {
            Dinosaurs.Remove(dinosaurToRemove);
        }

        public void SaveDinosaurs()
        {

            var fileWriter = new StreamWriter("Dinosaurs.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Dinosaurs);
            fileWriter.Close();

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
                Console.WriteLine("Ah-ah-ah, that isn't the magic input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static string PromptForDiet(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine().ToUpper();
            if (userInput == "C" || userInput == "H")
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Ah-ah-ah, that isn't the magic input, I'm using 0 as your answer.");
                return "UNKNOWN DINO DNA!";
            }

        }

        public static void RemoveDinosaur(DinosaurDatabase database)
        {
            Console.WriteLine();
            var nameToRemove = PromptForString("What dinosaur are you looking to remove? ");

            Dinosaur foundDinosaur = database.Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToRemove);

            if (foundDinosaur == null)
            {
                Console.WriteLine("Ah-ah-ah, no such Dino DNA!");
            }
            else

            {

                Console.WriteLine($"Clever Girl, the {foundDinosaur.Name} will be removed from Jurassic Park");

                var confirm = PromptForString("Are you sure? [Y/N] ").ToUpper();

                if (confirm == "Y")
                {

                    database.Dinosaurs.Remove(foundDinosaur);
                }

            }
        }

        public static void View(DinosaurDatabase database)
        {
            Console.WriteLine();
            var viewPreference = PromptForString("Would you like to view the dinosaurs ny (N)ame or (E)nclosure? ").ToUpper();
            Console.WriteLine();
            var viewByName = database.Dinosaurs.OrderBy(dinosaur => dinosaur.Name);
            var viewByEnclosure = database.Dinosaurs.OrderBy(dinosaur => dinosaur.EnclosureNumber);




            if (database.Dinosaurs.Count == 0)
            {
                Console.WriteLine(" Access Denied ...ah-ah-ah! You didn't say the magic word. -DN");
            }
            else if (viewPreference == "N")
            {
                foreach (var viewDinosaur in viewByName)

                {
                    viewDinosaur.DisplayDinosaur();
                }
            }
            else if (viewPreference == "E")
            {
                foreach (var viewDinosaur in viewByEnclosure)
                {
                    viewDinosaur.DisplayDinosaur();
                }
            }
        }


        public static void AddDinosaur(DinosaurDatabase database)
        {
            var dinosaur = new Dinosaur();
            Console.WriteLine();
            dinosaur.Name = PromptForString("What is the name of the dinosaur? ").ToUpper();
            dinosaur.DietType = PromptForString("Is it a (C)arnivore or a (H)erbivore? ").ToUpper();
            dinosaur.WhenAcquired = DateTime.Now;
            dinosaur.Weight = PromptForInteger("How much does the dino weigh, in pounds? ");
            dinosaur.EnclosureNumber = PromptForInteger("Please assign this dino to an enclosure number: ");

            database.Dinosaurs.Add(dinosaur);
        }

        private static void ShowAllDinosaurs(DinosaurDatabase database)
        {
            foreach (var dinosaur in database.GetAllDinosaurs())
            {
                Console.WriteLine($"Your Dino DNA says, {dinosaur.Name} is a {dinosaur.DietType} and is in enclosure: {dinosaur.EnclosureNumber}.");
            }





        }


    }
}





