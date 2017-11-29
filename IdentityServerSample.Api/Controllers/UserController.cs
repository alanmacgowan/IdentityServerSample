using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityServerSample.Data;

namespace IdentityServerSample.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class UserController : Controller
    {

        [Route("text/welcome")]
        [Authorize]
        public IActionResult GetWelcomeText()
        {
            return Content("Welcome " + User.Identity.Name);
        }

        [Route("user")]
        [Authorize]
        public IActionResult GetUser()
        {
            return Content("User: " + User.Identity.Name);
        }



    }

}
