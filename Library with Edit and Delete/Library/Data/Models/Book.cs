namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static Library.Common.EntityValidationConstants.Book;

    [Comment("Contains all books in the library.")]
    public class Book
    {
        [Comment("Book's primary key.")]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        //[MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;

        [Comment("Book's author.")]
        [Required]
        [MaxLength(AuthorMaxLength)]
        //[MinLength(AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Comment("Book's description.")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Comment("Book's image URL.")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Book's rating.")]
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        [Comment("Book's category ID.")]
        [Required]
        public int CategoryId { get; set; }
        [Comment("Book's category.")]
        [Required]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new HashSet<IdentityUserBook>();


    }
}

