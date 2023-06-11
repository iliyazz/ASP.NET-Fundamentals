namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    [Comment("Categories of books")]
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Comment("Category Id, Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Category Name, Required, Max length 50")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}

