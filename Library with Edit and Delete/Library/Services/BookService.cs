namespace Library.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllBookViewModel>> GetAllBookAsync()
        {
            return await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId)
        {
            return  await this.dbContext
                .UsersBooks
                .Where(b => b.CollectorId == userId)
                .Select(b => new MineBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }

        public async Task<MineBookViewModel?> GetBookByIdAsync(int id)
        {
            return await this.dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new MineBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Category = b.Category.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddBookToUserCollectionAsync(string useId, MineBookViewModel book)
        {
            bool isBookExistInCollection = await this.dbContext
                .UsersBooks
                .AnyAsync(b => b.BookId == book.Id && b.CollectorId == useId);
            if (!isBookExistInCollection)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = useId,
                    BookId = book.Id
                };
                await this.dbContext.UsersBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromUserCollectionAsync(string useId, MineBookViewModel book)
        {
            var userBook = this.dbContext
                .UsersBooks
                .FirstOrDefault(b => b.BookId == book.Id && b.CollectorId == useId);
            if (userBook != null)
            {
                this.dbContext.UsersBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }
        
        public async Task<AddNewBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await this.dbContext
                .Categories
                .Select(c => new AddNewBookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            var model = new AddNewBookViewModel()
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddNewBookAsync(AddNewBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = model.Rating
            };
            await this.dbContext.Books.AddAsync(book);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddNewBookViewModel?> GetBookByIdForEditAsync(int id)
        {
            var categories = await this.dbContext
                .Categories
                .Select(c => new AddNewBookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var book = await this.dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new AddNewBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    CategoryId = b.CategoryId,
                    Rating = b.Rating,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
            return book;
        }

        public async Task EditBookAsync(AddNewBookViewModel model, int id)
        {
           var book = await this.dbContext
               .Books
               .FirstOrDefaultAsync(b => b.Id == id);
           if (book != null)
           {
               book.Title = model.Title;
               book.Author = model.Author;
               book.ImageUrl = model.Url;
               book.Description = model.Description;
               book.CategoryId = model.CategoryId;
               book.Rating = model.Rating;

               await this.dbContext.SaveChangesAsync();
           }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await this.dbContext
                .Books
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                this.dbContext.Books.Remove(book);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetByOwnerBooksAsync(string getUserId)
        {
            var myBooks = await this.dbContext                .UsersBooks
                .Where(b => b.CollectorId == getUserId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Rating = b.Book.Rating,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
            return myBooks;
        }

    }
}
