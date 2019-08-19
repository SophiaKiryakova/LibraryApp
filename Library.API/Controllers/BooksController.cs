using Library.Business.Contracts;
using Library.Common.Providers;
using Library.Data.Dtos;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController: Controller
    {
        public IBooksService booksService;
        public IAuthorsService authorsService;

        public BooksController(IBooksService booksService, IAuthorsService authorsService, IMappingProvider mapper)
        {
            this.booksService = booksService;
            this.authorsService = authorsService;
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

        [HttpGet("{id}/author/{authorId}", Name = "GetBookForAuthor")]
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

        [HttpPost]
        public IActionResult CreateBookForAuthor(int authorId, [FromBody] BookCreateDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest();
            }

            var author = this.authorsService.GetAll().FirstOrDefault(a => a.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            var bookEntity = this.mapper.MapTo<Book>(bookDto);
            bookEntity.AuthorId = authorId;

            this.booksService.Add(bookEntity);

            return CreatedAtRoute("GetBookForAuthor", new { id = bookEntity.Id, authorId = authorId }, bookEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = this.booksService.GetAll().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            this.booksService.Delete(book);

            return NoContent();
        }

        private readonly IMappingProvider mapper;
    }
}
