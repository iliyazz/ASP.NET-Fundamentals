namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    [Comment("Books for Library")]
    public class Book
    {
        public Book()
        {
            this.UsersBooks = new HashSet<IdentityUserBook>();
        }
        [Comment("Book Id, Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Book Title, Required, Max length 50")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Comment("Book Author, Required, Max length 50")]
        [Required]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Comment("Book Description, Required, Max length 5000")]
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Comment("Book Image Url, Required")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Book Rating, Required")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Book Category Id, Required")]
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]

        [Comment("Book Category, Required")]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; }
    }
}


