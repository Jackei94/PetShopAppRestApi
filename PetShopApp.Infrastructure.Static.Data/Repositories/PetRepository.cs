using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
            if (FakeDB.Pets.Count >= 1) return;
            var pet1 = new Pet()
            {
                Name = "Zoey",
                Type = "Cat",
                Birthdate = new DateTime(2020, 06, 01),
                SoldTime = new DateTime(2020, 08, 18),
                Color = "White",
                PreviousOwner = "Lotte",
                Price = (0.0)
            };
            FakeDB.Pets.Add(pet1);

            var pet2 = new Pet()
            {
                Name = "Vax",
                Type = "Dog",
                Birthdate = new DateTime(2018, 11, 01),
                SoldTime = new DateTime(2019, 01, 01),
                Color = "White",
                PreviousOwner = "Karsten",
                Price = (700.0)
            };
            FakeDB.Pets.Add(pet2);
        }

        static int id = 1;
        private List<Pet> _pets = new List<Pet>();
        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;
        }

        public Pet ReadById(int id)
        {
            return FakeDB.Pets.
                Select(p => new Pet()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    Birthdate = p.Birthdate,
                    SoldTime = p.SoldTime,
                    Color = p.Color,
                    PreviousOwner = p.PreviousOwner,
                    Price = p.Price
                }).
                FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = ReadById(petUpdate.Id);
            if (petFromDB == null) return null;

            petFromDB.Name = petUpdate.Name;
            petFromDB.Type = petUpdate.Type;
            petFromDB.Birthdate = petUpdate.Birthdate;
            petFromDB.SoldTime = petUpdate.SoldTime;
            petFromDB.Color = petUpdate.Color;
            petFromDB.PreviousOwner = petUpdate.PreviousOwner;
            petFromDB.Price = petUpdate.Price;
            return petFromDB;
        }

        public Pet Delete(int id)
        {
            var petFound = ReadById(id);
            if (petFound == null) return null;

            FakeDB.Pets.Remove(petFound);
            return petFound;
        }
    }
}
