using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;
            _petRepo = petRepository;
        }

        public Owner NewOwner(string name)
        {
            var owner = new Owner()
            {
                Name = name
            };

            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            if(owner.Pet == null || owner.Pet.Id <= 0)
            {
                throw new InvalidDataException("To create owner you need a pet");
            }
            if(_petRepo.ReadById(owner.Pet.Id) == null)
            {
                throw new InvalidDataException("Pet not found");
            }
            return _ownerRepo.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public List<Owner> GetAllByName(string name)
        {
            var list = _ownerRepo.ReadAll();
            var queryContinued = list.Where(owner => owner.Name.Equals(name));
            queryContinued.OrderBy(owner => owner.Name);
            return queryContinued.ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.Id);
            owner.Name = ownerUpdate.Name;
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }
    }
}
