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
    public class ForumController : ControllerBase
    {
        private readonly IForumDAO forumDAO;
        public ForumController(IForumDAO _forumDAO)
        {
            forumDAO = _forumDAO;
        }

        [HttpGet("category")]
        public ActionResult<List<ForumCategory>> GetCategories()
        {
            //todo Link to forum DAO
            List<ForumCategory> categories = new List<ForumCategory>();

            try
            {
                categories = forumDAO.GetAllCategories();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            return Ok(categories);
        }

        [HttpPost("category")]
        public ActionResult<ForumCategory> PostCategory(ForumCategory category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    forumDAO.PostCategory(category);
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }

                return Created($"api/forum/category/{category.CategoryID}", category);
            }
        }

        [HttpPut("category/{category.CategoryID}")]
        public ActionResult<ForumCategory> UpdateCategory(ForumCategory category)
        {
            if(!ModelState.IsValid || category.CategoryID < 1)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    forumDAO.UpdateCategory(category);
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }

                return Ok(category);
            }
        }

        [HttpDelete("category/{category.CategoryID}")]
        public ActionResult DeleteCategory(ForumCategory category)
        {
            bool wasSuccessful;

            if(category.CategoryID < 1)
            {
                return BadRequest();
            }

            try
            {
                wasSuccessful = forumDAO.DeactivateCategory(category);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            if(wasSuccessful)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("message")]
        public ActionResult<List<ForumMessage>> GetAllMessages()
        {
            List<ForumMessage> messages = new List<ForumMessage>();

            try
            {
                messages = forumDAO.GetAllMessages();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                
            }
            return Ok(messages);
        }

        [HttpPost("message")]
        public ActionResult<ForumMessage> PostMessage(ForumMessage message)
        {
            if(!ModelState.IsValid || message.MessageID < 1)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    forumDAO.PostMessage(message);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Created($"/api/forum/message/{message.MessageID}", message);
            }
        }

        [HttpPut("message/{message.MessageID}")]
        public ActionResult<ForumMessage> UpdateMessage(ForumMessage message)
        {
            if (!ModelState.IsValid || message.MessageID < 1)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    forumDAO.UpdateMessage(message);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }

                return Ok(message);
            }
        }

        [HttpDelete("message/{message.MessageID}")]
        public ActionResult DeleteMessage(ForumMessage message)
        {
            bool wasSuccessful;

            if(message.MessageID < 1)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    wasSuccessful = forumDAO.DeactivateMessage(message);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                if (wasSuccessful)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                } 
            }
        }

        [HttpGet("response")]
        public ActionResult<List<ForumResponse>> GetAllResponses()
        {
            List<ForumResponse> responses = new List<ForumResponse>();

            try
            {
                responses = forumDAO.GetAllResponses();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            return Ok(responses);
        }

        [HttpPost("response")]
        public ActionResult<ForumResponse> PostResponse(ForumResponse response)
        {
            if(!ModelState.IsValid || response.ResponseID < 1)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    forumDAO.PostResponse(response);
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }

                return Created($"/forum/response/{response.ResponseID}", response);
            }
        }

        [HttpPut("response/{response.ResponseID}")]
        public ActionResult<ForumResponse> UpdateResponse(ForumResponse response)
        {
            if(!ModelState.IsValid || response.ResponseID < 1)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    forumDAO.UpdateResponse(response);
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }

                return Ok(response);
            }
        }

        [HttpDelete("response/{response.ResponseID}")]
        public ActionResult DeleteResponse(ForumResponse response)
        {
            bool wasSuccessful;

            if (response.ResponseID < 1)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    wasSuccessful = forumDAO.DeactivateResponse(response);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
                if (wasSuccessful)
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
}
