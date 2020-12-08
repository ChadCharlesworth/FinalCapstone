using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        //todo Add each DAO used for Pet with/without Dependency Injection?
        //private readonly DAO
        public PetController()
        {

        }

        [HttpGet("{userID}/{petID}")]
        public ActionResult<List<Pet>> GetPets(int userID)
        {
            //List<Pet> pets = userDAO.GetPet(userID);

            //if(pets.Count != 0)
            //{
            //    return Ok(pets);
            //}
            //else
            //{
            //    return NotFound();
            //}
            throw new Exception();

        }

        [HttpGet("{userID}")]
        public ActionResult<Profile> GetProfile(int userID)
        {
            //todo Link to user / profile DAO
            throw new Exception();
        }

        [HttpGet("{petID}")]
        public ActionResult<Pet> GetPetProfile(int petID)
        {
            //todo Link to pet DAO
            throw new Exception();
        }

        [HttpPost("{userID}")]
        public ActionResult<Pet> AddPet(Pet pet)
        {
            //todo Link to user / pet DAO 
            //created ({userID}/pet.id)
            throw new Exception();
        }

        
    }
}
