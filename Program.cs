using System;

namespace JurassicPark

{
    class Dinosaur
    {
        public string Name { get; set; }
        public string Diet { get; set; }
        public int Weight { get; set; }
        public int Enclosure { get; set; }
        public int Acquired { get; set; }

        //does this return date.time?



    }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("*************************");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Welcome to Jurassic Park!");
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("*************************");
            Console.WriteLine("-------------------------");

        }



        static void Main(string[] args)
        {
            DisplayGreeting();

        }
    }
}
