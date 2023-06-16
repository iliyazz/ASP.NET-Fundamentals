namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBookAsync();
        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId);
        Task<MineBookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToUserCollectionAsync(string useId, MineBookViewModel book);
        Task RemoveBookFromUserCollectionAsync(string useId, MineBookViewModel book);
        Task<AddNewBookViewModel> GetNewAddBookModelAsync();
        Task AddNewBookAsync(AddNewBookViewModel model);
        Task <AddNewBookViewModel?> GetBookByIdForEditAsync(int id);
        Task EditBookAsync(AddNewBookViewModel model, int id);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<AllBookViewModel>> GetByOwnerBooksAsync(string getUserId);
    }
}
