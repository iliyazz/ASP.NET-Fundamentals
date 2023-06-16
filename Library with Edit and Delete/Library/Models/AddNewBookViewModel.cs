namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Library.Common.EntityValidationConstants.Book;

    public class AddNewBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        [MinLength(AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<AddNewBookCategoryViewModel> Categories { get; set; } = new HashSet<AddNewBookCategoryViewModel>();
    }
}
