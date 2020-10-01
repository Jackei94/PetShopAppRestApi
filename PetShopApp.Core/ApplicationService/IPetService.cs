using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        //New Pet
        Pet NewPet(string name, string type, DateTime birthdate, DateTime soldTime, string color, string previousOwner, double price);

        //Create //POST
        Pet CreatePet(Pet pet);

        //Read //GET
        Pet FindPetById(int id);

        List<Pet> GetAllPets();

        List<Pet> GetAllByName(string name);

        //Update //PUT
        Pet UpdatePet(Pet petUpdate);

        //Delete //DELETE
        Pet DeletePet(int id);

    }
}
