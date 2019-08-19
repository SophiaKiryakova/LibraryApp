using Library.Data.Contracts;

namespace Library.Data.Dtos
{
    public class BookDto: BookCreateDto, IBaseDto
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
    }
}
