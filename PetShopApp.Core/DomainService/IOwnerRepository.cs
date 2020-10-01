using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        //OwnerRepository Interface
        //Create Data
        Owner Create(Owner owner);
        //Read Data
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll();
        //Update Data
        Owner Update(Owner ownerUpdate);
        //Delete Data
        Owner Delete(int id);
    }
}
