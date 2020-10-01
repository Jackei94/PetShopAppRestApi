using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    class PetTypeRepository : IPetTypeRepository
    {
        public PetTypeRepository()
        {
            if (FakeDB.PetTypes.Count > 0) return;

            var petType1 = new PetType()
            {
                Id = FakeDB.PetTypeId++,
                Pet = new Pet() { Id = 1 }
            };
            FakeDB.PetTypes.Add(petType1);

            var petType2 = new PetType()
            {
                Id = FakeDB.PetTypeId++,
                Pet = new Pet() { Id = 1 }
            };
            FakeDB.PetTypes.Add(petType2);
        }

        static int id = 1;
        private List<PetType> _petTypes = new List<PetType>();
        public PetType Create(PetType petType)
        {
            petType.Id = id++;
            _petTypes.Add(petType);
            return petType;
        }

        public IEnumerable<PetType> ReadAll()
        {
            return FakeDB.PetTypes;
        }

        public PetType ReadById(int id)
        {
            return FakeDB.PetTypes.FirstOrDefault(petType => petType.Id == id);
        }

        public PetType Update(PetType petTypeUpdate)
        {
            var petTypeFromDB = ReadById(petTypeUpdate.Id);

            if (petTypeFromDB != null)
            {
                petTypeFromDB.Type = petTypeUpdate.Type;
                return petTypeFromDB;
            }
            return null;
        }

        public PetType Delete(int id)
        {
            var petTypeFound = ReadById(id);
            if (petTypeFound == null) return null;

            FakeDB.PetTypes.Remove(petTypeFound);
            return petTypeFound;
        }
    }
}
