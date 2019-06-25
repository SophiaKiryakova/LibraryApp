using Library.Data.Contracts;

namespace Library.Data.Dtos
{
    public class BookDto: BaseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
    }
}
