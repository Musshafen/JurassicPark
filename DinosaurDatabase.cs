using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

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

        public void LoadDinosaurs()
            {
                var fileReader = new StreamReader("Dinosaurs.csv");
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,

                };
                var csvReader = new CsvReader(fileReader, config);

               

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

        public static void Remove(DinosaurDatabase database)
        {
            Console.WriteLine();
            var nameToRemove = PromptForString("What dinosaur are you looking to remove? ");
            Console.WriteLine();

            Dinosaur foundDinosaur = database.Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToRemove);

            if (foundDinosaur == null)
            {
                Console.WriteLine("Ah-ah-ah, no such Dino DNA!");
            }
            else


            {
                var confirm = PromptForString($"Clever Girl, are you sure you want to remove {foundDinosaur.Name}  [Y/N] ").ToUpper();

                if (confirm == "Y")
                {

                    database.Dinosaurs.Remove(foundDinosaur);
                }

            }
        }

        public static void View(DinosaurDatabase database)
        {
            Console.WriteLine();
            var viewPreference = PromptForString("Would you like to view the dinosaurs by (N)ame or (E)nclosure? ").ToUpper();
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

        public static void Summarize(DinosaurDatabase database)
        {
            var carnivores = database.Dinosaurs.Where(dinosaur => dinosaur.DietType == "C");
            var herbivores = database.Dinosaurs.Where(dinosaur => dinosaur.DietType == "H");
            Console.WriteLine($"Jurassic Park holds {herbivores.Count()} herbivores and {carnivores.Count()} carnivores.");
            //  foreach (var herbivore in herbivores)
            //{
            //   Console.WriteLine($"The herbivores are {herbivore.Name}, ");
            //}
            //  foreach (var carnivore in carnivores)
            //{
            //    Console.WriteLine($"The carnivores are: {carnivore.Name}, ")


        }
        public static void Transfer(DinosaurDatabase database)
        {
            Console.WriteLine();
            var nameToTransfer = PromptForString("What is the name of the dinosaur you'd like to transfer? ").ToUpper();
            Dinosaur moveDinosaur = database.Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == $"{nameToTransfer}");
            if (moveDinosaur == null)
            {
                Console.WriteLine();
                Console.WriteLine("Ah-ah-ah, there is no DINO DNA by that name. No wonder your extinct. ");
                Console.WriteLine();
            }
            else
            {

                Console.WriteLine();
                Console.WriteLine($"{moveDinosaur.Name} is currently in Enclosure {moveDinosaur.EnclosureNumber}.");
                Console.WriteLine();
                moveDinosaur.EnclosureNumber = PromptForInteger($"Please enter {moveDinosaur.Name}'s new enclosure number: ");
                Console.WriteLine();


            }



        }
    }
}




