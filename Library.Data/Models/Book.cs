using Library.Data.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Book: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
