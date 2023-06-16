namespace Library.Models
{
    public class MineBookViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Author { get; init; } = null!;

        public string Description { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public string Category { get; init; } = null!;
    }
}


