using System;

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
            var dinosaur = new Dinosaur();

            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do (A)dd a dinosaur or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "Q")
                {
                    keepGoing = false;
                }
                else
                {
                    var dinosaur = new Dinosaur();

                    dinosaur.Name = PromptForString("What is your name? ");
                    dinosaur.DietType = PromptForString("")

                }
            }
        }
    }
}