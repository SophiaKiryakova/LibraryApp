using Library.Data.Contracts;

namespace Library.Data.Dtos
{
    public class AuthorDto: BaseDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Genre { get; set; }
    }
}
