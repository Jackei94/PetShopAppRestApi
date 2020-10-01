using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetTypeService
    {
        //New Type
        PetType NewPetType(string type);

        //Create //POST
        PetType CreatePetType(PetType PetType);

        //Read //GET
        PetType FindPetTypeById(int id);

        List<PetType> GetAllPetTypes();

        List<PetType> GetAllByType(string type);

        //Update //PUT
        PetType UpdatePetType(PetType petTypeUpdate);

        //Delete //DELETE
        PetType DeletePetType(int id);
    }
}
