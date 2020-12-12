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
    public class PlaydateController : ControllerBase
    {
        private readonly IPlaydateDAO playdateDAO;
        public PlaydateController(IPlaydateDAO _playdateDAO)
        {
            playdateDAO = _playdateDAO;
        }
        [HttpGet]
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

        [HttpPost]
        public ActionResult<Playdate> CreatePlaydate( [FromBody] Playdate newPlaydate/*, int petID*/)
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
    }
}
