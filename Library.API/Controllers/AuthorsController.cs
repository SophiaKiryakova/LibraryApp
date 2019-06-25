using Library.Business.Contracts;
using Library.Common.Providers;
using Library.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        public IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService, IMappingProvider mapper)
        {
            this.authorsService = authorsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = this.authorsService.GetAll();
            var authorsDtos = this.mapper.ProjectTo<AuthorDto>(authors);

            return Ok(authorsDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var author = this.authorsService.GetAll().FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            var authorDto = this.mapper.MapTo<AuthorDto>(author);

            return new JsonResult(author);
        }

        private readonly IMappingProvider mapper;
    }
}
