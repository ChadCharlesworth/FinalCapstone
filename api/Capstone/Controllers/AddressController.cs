using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressDAO addressDAO;

        public AddressController(IAddressDAO _addressDAO)
        {
            addressDAO = _addressDAO;
        }

        [HttpGet]
        public ActionResult<List<Address>> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();

            try
            {
                addresses = addressDAO.GetAddresses();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(addresses);
        }

        [HttpPost]
        public ActionResult<Address> AddAddress([FromBody] Address newAddress)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    addressDAO.AddAddress(newAddress);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                return Created($"api/address/{newAddress.Address_ID}", newAddress);
            }
        }

        [HttpPost("user/{userID}")]
        public ActionResult<Address> AddAddressWithUser(int userID, [FromBody] Address newAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    addressDAO.AddAddressWithUser(newAddress, userID);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                return Created($"api/address/{newAddress.Address_ID}", newAddress);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Address> UpdateAddress(int id, [FromBody] Address updatedAddress)
        {
            if (!ModelState.IsValid || updatedAddress.Address_ID != id)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    addressDAO.UpdateAddress(updatedAddress);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(updatedAddress);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            bool deleteSuccessful;

            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                deleteSuccessful = addressDAO.DeleteAddress(id);
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




