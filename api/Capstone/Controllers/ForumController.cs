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
    public class ForumController : ControllerBase
    {
        //private readonly DAO
        public ForumController()
        {

        }

        [HttpGet("/category")]
        public ActionResult<List<ForumCategory>> GetCategory()
        {
            //todo Link to forum DAO
            throw new Exception();
            
        }

        [HttpGet("/category/")]
        public ActionResult<List<ForumMessage>> GetAllMessages(int categoryID)
        {
            throw new Exception();
        }

        [HttpGet("/category/{message.id}")]
        public ActionResult<ForumMessage> GetMessages(int categoryID, int messageID)
        {
            //todo Link to Forum/Message DAO
            throw new NotImplementedException();
        }
    }
}
