namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using static Library.Common.EntityValidationConstants.Category;

    [Comment("Contains all categories in the library.")]
    public class Category
    {
        [Comment("Category's primary key.")]
        [Key]
        public int Id { get; set; }

        [Comment("Category's name.")]
        [Required]
        [MaxLength(NameMaxLength)]
        //[MinLength(NameMinLength)]
        public string Name { get; set; } = null!;
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}


