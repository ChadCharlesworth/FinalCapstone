using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetController : ControllerBase
    {
        //todo Add each DAO used for Pet with/without Dependency Injection?
        //private readonly DAO
        private readonly IPetDAO petDAO;
        public PetController(IPetDAO _petDAO)
        {
            petDAO = _petDAO;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Pet>> GetPets()
        {
            List<Pet> pets = new List<Pet>();

            try
            {
                pets = petDAO.GetPets();
                if (pets.Count != 0)
                {
                    return Ok(pets);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Pet> AddPet(Pet newPet)
        {
            {

                try
                {
                    newPet = petDAO.AddPet(newPet);
                    if (newPet != null)
                    {
                        return Ok(newPet);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            //todo Link to user / pet DAO 
            //created ({userID}/pet.id)
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePet(int id)
        {
            bool deleteSuccessful;

            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                deleteSuccessful = petDAO.DeletePet(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            if (deleteSuccessful)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Pet> UpdatePet(Pet updatePet, int id)
        {
            if(!ModelState.IsValid || updatePet.Pet_ID != id)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    petDAO.UpdatePet(updatePet);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                return Ok(updatePet);
            }
        }
    }
}