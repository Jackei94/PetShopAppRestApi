using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;

namespace PetShopAppRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        //GET Api
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        //GET Api
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID must be greater than 0");
            }

            return _petService.FindPetById(id);
        }

        //POST Api
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if(string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is required for creating pet");
            }
            //return StatusCode(503, "Horrible Error: Call Tech-Support");
            return _petService.CreatePet(pet);
        }

        //PUT Api
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if(id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter ID and pet ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));
        }

        //DELETE Api
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find pet with ID" + id);
            }
            return Ok($"Pet with ID: {id} is deleted");
        }
    }
}
