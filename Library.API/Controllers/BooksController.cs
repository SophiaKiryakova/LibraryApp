using Library.Business.Contracts;
using Library.Common.Providers;
using Library.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController: Controller
    {
        public IBooksService booksService;

        public BooksController(IBooksService booksService, IMappingProvider mapper)
        {
            this.booksService = booksService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            var books = this.booksService.GetAll();
            var booksDtos = this.mapper.ProjectTo<BookDto>(books);

            return Ok(booksDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = this.booksService.GetAll().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = this.mapper.MapTo<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpGet("author/{authorId}")]
        public IActionResult GetAuthorBooks(int authorId)
        {
            var books = this.booksService.GetBooksForAuthor(authorId);
            var booksDtos = this.mapper.ProjectTo<BookDto>(books);

            return Ok(booksDtos);
        }

        [HttpGet("{id}/author/{authorId}")]
        public IActionResult GetBookForAuthor(int id, int authorId)
        {
            var book = this.booksService.GetBookForAuthor(id, authorId);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = this.mapper.MapTo<BookDto>(book);

            return Ok(bookDto);
        }

        private readonly IMappingProvider mapper;
    }
}
