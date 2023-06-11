namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookCategoryViewModel
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public string Name { get; set; }
    }
}

