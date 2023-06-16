namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Identity User Book.")]
    public class IdentityUserBook
    {
        [Comment("Collector's primary key.")]
        [Key]
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; } = null!;
        public IdentityUser Collector { get; set; } = null!;

        [Comment("Book's primary key.")]
        [Key]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}

