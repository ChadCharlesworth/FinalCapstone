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
    //[Authorize]
    public class PlaydateController : ControllerBase
    {
        private readonly IPlaydateDAO playdateDAO;
        public PlaydateController(IPlaydateDAO _playdateDAO)
        {
            playdateDAO = _playdateDAO;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Playdate>> GetAllPlaydates()
        {
            List<Playdate> playdates = new List<Playdate>();

            try
            {
                playdates = playdateDAO.GetAllPlaydates();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(playdates);
        }

        [HttpGet("{playdateID}")]
        [AllowAnonymous]
        public ActionResult<Playdate> GetPlaydate(int playdateID)
        {
            Playdate playdate = new Playdate();
            {
                try
                {
                    playdate = playdateDAO.GetPlaydate(playdateID);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(playdate);

            }
        }

        [HttpPost]
        public ActionResult<Playdate> CreatePlaydate([FromBody] Playdate newPlaydate/*, int petID*/)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    playdateDAO.CreatePlaydate(newPlaydate/*, petID*/);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Created($"api/playdate/{newPlaydate.Playdate_ID}", newPlaydate);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Playdate> UpdatePlaydate(int id, [FromBody] Playdate updatedPlaydate)
        {
            if (!ModelState.IsValid || updatedPlaydate.Playdate_ID != id)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    playdateDAO.UpdatePlaydate(updatedPlaydate);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(updatedPlaydate);
            }
        }
        [HttpDelete("{id}/decline/pet/{petID}")]
        public ActionResult<Playdate> DeclinePlaydateByPetID(int id, int petID)
        {
            try
            {
                playdateDAO.DeclinePlaydateByPetID(id, petID);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return NoContent();

        }

        [HttpDelete("{id}/accept/pet/{petID}")]
        public ActionResult<Playdate> AcceptPlaydateByPetID(int id, int petID)
        {
            try
            {
                playdateDAO.AcceptPlaydateByPetID(id, petID);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return NoContent();

        }

        [HttpDelete("{id}/pending/pet/{petID}")]
        public ActionResult<Playdate> PendingPlaydateByPetID(int id, int petID)
        {
            try
            {
                playdateDAO.PendingPlaydateByPetID(id, petID);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return NoContent();

        }




        [HttpPut("{id}/pet/{petID}")]
        public ActionResult<Playdate> UpdatePlaydateByPetID(int id, [FromBody] Playdate updatedPlaydate, int petID)
        {
            if (!ModelState.IsValid || updatedPlaydate.Playdate_ID != id) //ADDING PET ID REFERENCE??
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    playdateDAO.UpdatePlaydateByPetID(updatedPlaydate, petID);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(updatedPlaydate);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlaydate(int id)
        {
            bool deleteSuccessful;

            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                deleteSuccessful = playdateDAO.DeletePlaydate(id);
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

        [HttpGet("owner/{ownerID}")]
        [AllowAnonymous]
        public ActionResult<List<Playdate>> GetPlaydatesByPetOwner(int ownerID)
        {
            List<Playdate> playdates = new List<Playdate>();

            try
            {
                playdates = playdateDAO.GetPlaydatesByPetOwner(ownerID);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(playdates);
        }

    }
}
