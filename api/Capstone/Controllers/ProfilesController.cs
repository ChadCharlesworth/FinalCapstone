using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileDAO profileDAO;

        public ProfilesController(IProfileDAO _profileDAO)
        {
            profileDAO = _profileDAO;
        }

        // GET: api/<ProfilesController>
        [HttpGet]
        public ActionResult<List<Profile>> GetUsers()
        {
            List<Profile> profiles = new List<Profile>();

            try
            {
                profiles = profileDAO.GetAllUsers();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(profiles);
        }

        // GET api/<ProfilesController>/5
        [HttpGet("{id}")]
        public ActionResult<Profile> GetUserByUsername(int id)
        {
            Profile profile = new Profile();

            try
            {
                profile = profileDAO.GetProfile(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            if (profile.username != null)
            {
                return Ok(profile); 
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT api/<ProfilesController>/5
        [HttpPut("{id}")]
        public ActionResult<Profile> UpdateProfile(int id, [FromBody] Profile updatedProfile)
        {
            if (!ModelState.IsValid || updatedProfile.user_id != id)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    profileDAO.UpdateProfile(updatedProfile);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(updatedProfile);
            }

        }

        // DELETE api/<ProfilesController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProfile(int id)
        {
            bool deleteSuccessful;

            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                deleteSuccessful = profileDAO.DeleteProfile(id);
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
    }
}
