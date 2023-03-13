using System;
using System.Globalization;
using System.IO;
using CsvHelper;

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


        static void Main(string[] args)
        {
            var database = new DinosaurDatabase();


            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.Write("What do you want to do?\n(A)dd a dinosaur to the park\n(D)elete a dinosaur\n(S)how all the dinosaurs\n(T)ransfer a dinosaur\n(V)iew a dinosaur\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();


                switch (choice)
                {
                    case "Q":

                        keepGoing = false;
                        break;
                    case "D":
                        DeleteDinosaur(database);
                        break;

                    case "V":
                        FindDinosaur(database);
                        break;
                    case "S":

                        ShowAllDinosaurs(database);
                        break;

                    case "T":
                        {
                            

                        }
                        break;
                    case "A":
                        AddDinosaur(database);
                        break;
                    default:

                        Console.WriteLine("Ah-ah-ah, You didn't say the magic word! ");
                        break;

                }

            }
        }

       