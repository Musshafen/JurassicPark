using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace JurassicPark

{
    class DinosaurDatabase
    {

        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
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


    }


}
