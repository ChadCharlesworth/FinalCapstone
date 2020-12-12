using Capstone.DAO;
using Capstone.Models;
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
    public class PetController : ControllerBase
    {
        //todo Add each DAO used for Pet with/without Dependency Injection?
        //private readonly DAO
        private readonly IPetDAO petDAO;
        public PetController(IPetDAO _petDAO)
        {
            petDAO = _petDAO;
        }

        [HttpPost("{userID}")]
        public ActionResult<Pet> AddPet(Pet newPet);
        {
            
        }
    public ActionResult<Pet> UpdatePet(Pet updatePet);
        {
            
        }

[HttpGet]
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

[HttpGet("{petID}")]
public ActionResult<Pet> GetPetProfile(int petID)
{
    {
        List<Pet> pets = new List<Pet>();

        try
        {
            pets = petDAO.GetPetProfile();
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
    //todo Link to pet DAO
}

[HttpPost("{userID}")]
public ActionResult<Pet> AddPet(Pet newPet)
{
    {
        List<Pet> pets = new List<Pet>();

        try
        {
            pets = petDAO.newPet();
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
    //todo Link to user / pet DAO 
    //created ({userID}/pet.id)
}
[HttpDelete]
public bool DeletePet(int id);
{

}