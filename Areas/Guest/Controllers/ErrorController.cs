using DoctorDoc1.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Areas.Guest.Controllers
{
    [Route("errors/{code}")]
    // https://localhost:44303/swagger
    // this will be now ignored by swagger
    // swagger doesn't produce this inside our documentation
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
