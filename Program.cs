using System;

namespace JurassicPark

{

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
            var database = new DinosaurDatabase();


            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\n(A)dd a dinosaur\n(D)elete a dinosaur\n(F)ind a dinosaur\n(S)how all the dinosaurs\n(U)pdate a dinosaur\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

              

                if (choice == "Q")
                {
                    keepGoing = false;

                }
                else
                if (choice == "D")
                {
                    DeleteDinosaur(database);

                }
                else
                if (choice == "F")
                {
                    FindDinosaur(database);

                }
                else
                if (choice == "S")
                {
                    ShowAllDinosaurs(database);
                }
                else
                    if (choice == "U")
                {
                    var nameToSearchFor = PromptForString("What dinosaur are you looking for? ");

                    Dinosaur foundDinosaur = database.FindOneDinosaur(nameToSearchFor);

                    if (foundDinosaur == null)
                    {
                        Console.WriteLine("Ah-ah-ah, no such Dino DNA!");
                    }
                    else
                    {

                        Console.WriteLine($"Your Dino DNA says, {foundDinosaur.Name} is a {foundDinosaur.DietType} and is in enclosure: {foundDinosaur.EnclosureNumber}.");
                        var changeChoice = PromptForString("What do you want to change [Name/DietType/EnclosureNumber]? ").ToUpper();

                        if (changeChoice == "NAME")
                        {
                            foundDinosaur.Name = PromptForString("What is the new name?: ");
                        }

                        if (changeChoice == "DIETTYPE")
                        {
                            foundDinosaur.DietType = PromptForString("What is the new diet type? ");
                        }

                        if (changeChoice == "ENCLOSURE")
                        {
                            foundDinosaur.EnclosureNumber = PromptForInteger("What is the new enclosure number? ");


                        }



                    }

                }
                else
                if (choice == "A")
                    AddDinosaur(database);
                else
                {
                    Console.WriteLine("Ah-ah-ah, You didn't say the magic word! ");
                }

            }

        }

        private static void DeleteDinosaur(DinosaurDatabase database)
        {
            var nameToSearchFor = PromptForString("What dinosaur are you looking for? ");

            Dinosaur foundDinosaur = database.FindOneDinosaur(nameToSearchFor);

            if (foundDinosaur == null)
            {
                Console.WriteLine("Ah-ah-ah, no such Dino DNA!");
            }
            else

            {

                Console.WriteLine($"Your Dino DNA says, {foundDinosaur.Name} is a {foundDinosaur.DietType} and is in enclosure: {foundDinosaur.EnclosureNumber}.");

                var confirm = PromptForString("Are you sure? [Y/N] ").ToUpper();

                if (confirm == "Y")
                {

                    database.DeleteDinosaur(foundDinosaur);
                }

            }
        }

        private static void FindDinosaur(DinosaurDatabase database)
        {
            var nameToSearchFor = PromptForString("What dinosaur are you looking for? ");

            Dinosaur foundDinosaur = database.FindOneDinosaur(nameToSearchFor);


            if (foundDinosaur == null)
            {
                Console.WriteLine(" Access Denied ...ah-ah-ah! You didn't say the magic word. -DN");
            }
            else
            {
                Console.WriteLine($"Your Dino DNA says, {foundDinosaur.Name} is a {foundDinosaur.DietType} and is in enclosure: {foundDinosaur.EnclosureNumber}.");
            }
        }

        private static void AddDinosaur(DinosaurDatabase database)
        {
            var dinosaur = new Dinosaur();

            dinosaur.Name = PromptForString("What is the name of the dinosaur? ");
            dinosaur.DietType = PromptForString("Is it a (C)arnivore or a (H)erbivore? ").ToUpper();
            dinosaur.WhenAcquired = DateTime.Now;
            dinosaur.Weight = PromptForInteger("How much does the dino weigh, in pounds? ");
            dinosaur.EnclosureNumber = PromptForInteger("Please assign this dino to an enclosure number: ");

            database.AddDinosaur(dinosaur);
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