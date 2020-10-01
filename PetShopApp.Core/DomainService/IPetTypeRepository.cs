using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IPetTypeRepository
    {
        //TypeRepository Interface
        //Create Data
        PetType Create(PetType petType);
        //Read Data
        PetType ReadById(int id);
        IEnumerable<PetType> ReadAll();
        //Update Data
        PetType Update(PetType petTypeUpdate);
        //Delete Data
        PetType Delete(int id);
    }
}
