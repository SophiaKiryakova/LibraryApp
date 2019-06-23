using Library.Business.Contracts;
using Library.Common.Providers;
using Library.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController: Controller
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

            return new JsonResult(authorsDtos);
        }

        private readonly IMappingProvider mapper;
    }
}
