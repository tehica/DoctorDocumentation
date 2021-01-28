using DoctorDoc1.Data;
using DoctorDoc1.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class BugController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BugController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("secrettext")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _db.City.Find(999);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _db.City.Find(999);

            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
