using Library.Data.Dtos;
using System;
using System.Collections.Generic;

namespace Library.Data.Dtos
{
    public class AuthorCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Genre { get; set; }

        public IEnumerable<BookCreateDto> Books { get; set; } = new List<BookCreateDto>();
    }
}
