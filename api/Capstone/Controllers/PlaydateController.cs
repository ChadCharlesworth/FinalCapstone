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
    public class PlaydateController : ControllerBase
    {
        //private readonly DAO
        public PlaydateController()
        {

        }
        [HttpGet("{playdateID}")]
        public ActionResult<Playdate> GetPlaydate(int playdateID)
        {
            //todo Link to playdate DAO
            throw new Exception();
        }

        [HttpPost]
        public ActionResult<Playdate> AddPlaydate(Playdate playdate)
        {
            //todo Link to playdate DAO
            // created("/playdate.id")
            throw new Exception();
        }
    }
}
