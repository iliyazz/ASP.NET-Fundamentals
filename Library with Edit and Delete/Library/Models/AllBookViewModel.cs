namespace Library.Models
{
    public class AllBookViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Author { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public decimal Rating { get; init; }

        public string Category { get; init; } = null!;

        public string OwnerId { get; init; } = null!;
    }
}

