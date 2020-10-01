using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAppRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        //GET Api
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return Ok(_ownerService.GetAllOwners());
        }

        //GET Api
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID must be greater than 0");
            }

            return Ok(_ownerService.FindOwnerById(id));
        }

        //POST Api
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.CreateOwner(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        //PUT Api
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter ID and owner ID must be the same");
            }

            return Ok(_ownerService.UpdateOwner(owner));
        }

        //DELETE Api
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find owner with ID" + id);
            }
            return Ok($"Owner with ID: {id} is deleted");
        }
    }
}
