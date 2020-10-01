using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        //New Owner
        Owner NewOwner(string name);

        //Create //POST
        Owner CreateOwner(Owner owner);

        //Read //GET
        Owner FindOwnerById(int id);

        List<Owner> GetAllOwners();

        List<Owner> GetAllByName(string name);

        //Update //PUT
        Owner UpdateOwner(Owner ownerUpdate);

        //Delete //DELETE
        Owner DeleteOwner(int id);
    }
}
