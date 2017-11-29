using IdentityServerSample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerSample.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("GetBooks")]
        [Authorize]
        public IActionResult GetBooks()
        {
            var books = _context.Books.AsNoTracking().ToList(); ;
            return new JsonResult(books);
        }


    }
}
