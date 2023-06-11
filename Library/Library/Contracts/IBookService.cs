namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToUserAsync(BookViewModel book, string userId);
        Task RemoveBookFromUserAsync(BookViewModel book, string userId);
        Task<AddBookViewModel> GetNewBookAsync();
        Task AddNewBookAsync(AddBookViewModel model);
        Task<AddBookViewModel?> GetBookByIdForEditAsync(int id);
        Task EditBookAsync(AddBookViewModel model, int id);
    }
}
