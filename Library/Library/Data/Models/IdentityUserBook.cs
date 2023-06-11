namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Comment("Identity User Book")]
    public class IdentityUserBook
    {
        [Comment("Book collector Id, Primary key")]
        public string CollectorId { get; set; } = null!;

        [Comment("Book collector, Required")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Comment("Book Id, Primary key")]
        public int BookId { get; set; }

        [Comment("Book, Required")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}


