using Library.Business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController: Controller
    {
        public IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = this.authorsService.GetAll();

            return new JsonResult(authors);
        }
    }
}
