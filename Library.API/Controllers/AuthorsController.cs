using Library.Business.Contracts;
using Library.Common.Providers;
using Library.Data.Dtos;
using Library.Data.Models;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}", Name = "GetAuthor")]
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

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] AuthorCreateDto authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest();
            }

            var author = this.mapper.MapTo<Author>(authorDto);
            this.authorsService.Add(author);

            var authorCreated = this.mapper.MapTo<AuthorDto>(author);

            return CreatedAtRoute("GetAuthor", new { id = authorCreated.Id }, authorCreated);
        }

        [HttpPost("{id}")]
        public IActionResult BlockAuthorCreation(int id)
        {
            var author = this.authorsService.GetAll().FirstOrDefault(a => a.Id == id);

            if (author != null)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = this.authorsService.GetAll().FirstOrDefault(b => b.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            this.authorsService.Delete(author);

            return NoContent();
        }

        private readonly IMappingProvider mapper;
    }
}
