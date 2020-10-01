using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class PetTypeService : IPetTypeService
    {
        readonly IPetTypeRepository _petTypeRepo;
        readonly IPetRepository _petRepo;

        public PetTypeService(IPetTypeRepository petTypeRepository, IPetRepository petRepository)
        {
            _petTypeRepo = petTypeRepository;
            _petRepo = petRepository;
        }

        public PetType NewPetType(string type)
        {
            var petType = new PetType()
            {
                Type = type
            };

            return petType;
        }

        public PetType CreatePetType(PetType petType)
        {
            if (petType.Pet == null || petType.Pet.Id <= 0)
            {
                throw new InvalidDataException("To create pet type you need a pet");
            }
            if (_petRepo.ReadById(petType.Pet.Id) == null)
            {
                throw new InvalidDataException("Pet type not found");
            }
            return _petTypeRepo.Create(petType);
        }

        public PetType FindPetTypeById(int id)
        {
            return _petTypeRepo.ReadById(id);
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepo.ReadAll().ToList();
        }

        public List<PetType> GetAllByType(string type)
        {
            var list = _petTypeRepo.ReadAll();
            var queryContinued = list.Where(petType => petType.Type.Equals(type));
            queryContinued.OrderBy(petType => petType.Type);
            return queryContinued.ToList();
        }

        public PetType UpdatePetType(PetType petTypeUpdate)
        {
            var petType = FindPetTypeById(petTypeUpdate.Id);
            petType.Type = petTypeUpdate.Type;
            return petType;
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepo.Delete(id);
        }
    }
}
