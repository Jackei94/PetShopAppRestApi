using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {
            if(FakeDB.Owners.Count > 0) return;

            var owner1 = new Owner()
            {
                Id = FakeDB.OwnerId++,
                Pet = new Pet() { Id = 1}
            };
            FakeDB.Owners.Add(owner1);

            var owner2 = new Owner()
            {
                Id = FakeDB.OwnerId++,
                Pet = new Pet() { Id = 1 }
            };
            FakeDB.Owners.Add(owner2);
        }

        static int id = 1;
        private List<Owner> _owners = new List<Owner>();
        public Owner Create(Owner owner)
        {
            owner.Id = id++;
            _owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners;
        }

        public Owner ReadById(int id)
        {
            return FakeDB.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = ReadById(ownerUpdate.Id);

            if (ownerFromDB != null)
            {
                ownerFromDB.Name = ownerUpdate.Name;
                return ownerFromDB;
            }
            return null;
        }

        public Owner Delete(int id)
        {
            var ownerFound = ReadById(id);
            if (ownerFound == null) return null;

            FakeDB.Owners.Remove(ownerFound);
            return ownerFound;
        }
    }
}

