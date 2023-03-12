using System.Collections.Generic;
using System.Linq;

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

        public Dinosaur FindOneDinosaur(string nameToFind)
        {
            Dinosaur foundDinosaur = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundDinosaur;
        }

        public void DeleteDinosaur(Dinosaur dinosaurToDelete)
        {
            Dinosaurs.Remove(dinosaurToDelete);
        }




    }
}