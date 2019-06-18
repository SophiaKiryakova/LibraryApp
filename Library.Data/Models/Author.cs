using Library.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Author: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        public ICollection<Book> Books { get; set; }
            = new List<Book>();
    }
}
