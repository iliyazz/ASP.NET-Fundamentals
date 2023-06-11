namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddBookViewModel
    {

        public AddBookViewModel()
        {
            this.Categories = new List<BookCategoryViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<BookCategoryViewModel> Categories { get; set; }
    }
}


