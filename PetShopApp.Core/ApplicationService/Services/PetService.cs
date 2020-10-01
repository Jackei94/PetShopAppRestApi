using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        public Pet NewPet(string name, string type, DateTime birthdate, DateTime soldTime, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthdate,
                SoldTime = soldTime,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public List<Pet> GetAllByName(string name)
        {
            var list = _petRepo.ReadAll();
            var queryContinued = list.Where(pet => pet.Name.Equals(name));
            queryContinued.OrderBy(pet => pet.Name);
            return queryContinued.ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.Birthdate = petUpdate.Birthdate;
            pet.SoldTime = petUpdate.SoldTime;
            pet.Color = petUpdate.Color;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }
    }
}
