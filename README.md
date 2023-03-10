# JurassicPark

using System;

namespace JurassicPark

{
class Dinosaur
{
public string Name { get; set; }
public string DietType { get; set; }
public int Weight { get; set; }
public int EnclosureNumber { get; set; }
public DateTime WhenAcquired { get; set; }

        public void DisplayDinosaurs()
        {
            Console.WriteLine($"Name: {Name} ");
            Console.WriteLine($"Diet: {DietType} ");
            Console.WriteLine($"Weight: {Weight} ");
            Console.WriteLine($"Acquired: {WhenAcquired} ");
            Console.WriteLine($"Enclosure: {EnclosureNumber} ");
            Console.WriteLine();

        }

    }

    class DinosaurDatabase
    {

        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddDinosaur(Dinosaur add)
        {
            Dinosaurs.Add(add);
        }
        public void RemoveDinosaur(Dinosaur remove)
        {
            Dinosaurs.Remove(remove);
        }
        public Dinosaur ViewOneDinosaur(string dinoToFind)
        {
            Dinosaur foundDinosaur = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name.ToUpper().Contains(dinoToFind.ToUpper()));
            return foundDinosaur;
        }
        public List<Dinosaur> ViewAllDionsaurs()
        {
            return Dinosaurs;
        }
        public void LoadDinosaur()
        {
            if (File.Exists("Dinosaur.csv"))
            {
                var fileReader = new StreamReader("Dinosaurs.cvs");

            }
        }

    }

}

class Program
{
static void DisplayGreeting()
{
Console.WriteLine("-------------------------");
Console.WriteLine("************\*************");
Console.WriteLine("-------------------------");
Console.WriteLine();
Console.WriteLine("Welcome to Jurassic Park!");
Console.WriteLine();
Console.WriteLine("-------------------------");
Console.WriteLine("************\*************");
Console.WriteLine("-------------------------");

    }



    static void Main(string[] args)
    {
        DisplayGreeting();

        var database = new DinosaurDatabase();


    }


}
}
