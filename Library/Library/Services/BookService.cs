namespace Library.Services
{
    using System.Security.Cryptography.X509Certificates;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {

            return await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await this.dbContext
                .IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBookViewModel
                {
                    Id = b.BookId,
                    ImageUrl = b.Book.ImageUrl,
                    Title = b .Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await this.dbContext                
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Url = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    CategoryId = b.Category.Id,
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddBookToUserAsync(BookViewModel book, string userId)
        {
             bool isBookExist = await this.dbContext    
                 .IdentityUserBooks
                .AnyAsync(ub => ub.BookId == book.Id && ub.CollectorId == userId);
             if (!isBookExist)
             {
                var userBook = new IdentityUserBook
                {
                    BookId = book.Id,
                    CollectorId = userId
                };
                await this.dbContext.IdentityUserBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
             }
        }

        public async Task RemoveBookFromUserAsync(BookViewModel book, string userId)
        {
            var userBook = await this.dbContext
                .IdentityUserBooks
                .FirstOrDefaultAsync(ub => ub.BookId == book.Id && ub.CollectorId == userId);
            if (userBook != null)
            {
                this.dbContext.IdentityUserBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> GetNewBookAsync()
        {
            var categories = await this.dbContext
                .Categories
                .Select(c => new BookCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddNewBookAsync(AddBookViewModel model)
        {
             Book book = new Book()
             {
                 Title = model.Title,
                 Author = model.Author,
                 Description = model.Description,
                 ImageUrl = model.Url,
                 Rating = model.Rating,
                 CategoryId = model.CategoryId
             };
             await this.dbContext.Books.AddAsync(book);
             await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddBookViewModel?> GetBookByIdForEditAsync(int id)
        {
            var categories = await this.dbContext
                .Categories
                .Select(c => new BookCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            var model = await this.dbContext   
                .Books
                .Where(b => b.Id == id)
                .Select(b => new AddBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Url = b.ImageUrl,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task EditBookAsync(AddBookViewModel model, int id)
        {
            var book = await this.dbContext
                .Books
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.Description = model.Description;
                book.ImageUrl = model.Url;
                book.Rating = model.Rating;
                book.CategoryId = model.CategoryId;
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
