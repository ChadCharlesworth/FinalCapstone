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

        [HttpPut("message/{messageID}")]
        public ActionResult<ForumMessage> UpdateMessage(int messageID, ForumMessage message)
        {
            if (!ModelState.IsValid || message.MessageID != messageID)
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

        [HttpDelete("message/{messageID}")]
        public ActionResult DeleteMessage(int messageID)
        {
            bool wasSuccessful;

            try
            {
                wasSuccessful = forumDAO.DeactivateMessage(messageID);
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
            if (!ModelState.IsValid)
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

        [HttpPut("response/{responseID}")]
        public ActionResult<ForumResponse> UpdateResponse(int responseID, ForumResponse response)
        {
            if (!ModelState.IsValid || response.ResponseID != responseID)
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

        [HttpDelete("response/{responseID}")]
        public ActionResult DeleteResponse(int responseID)
        {
            bool wasSuccessful;

            try
            {
                wasSuccessful = forumDAO.DeactivateResponse(responseID);
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
