namespace Library.Controllers
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var models = await this.bookService.GetAllBookAsync();

            return this.View(models);
        }

        public async Task<IActionResult> Mine()
        {
            var models = await this.bookService.GetMineBooksAsync(GetUserId());

            return this.View(models);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }
            var userId = GetUserId();
            await this.bookService.AddBookToUserCollectionAsync(userId, book);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }
            var userId = GetUserId();
            await this.bookService.RemoveBookFromUserCollectionAsync(userId, book);
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await this.bookService.GetNewAddBookModelAsync();
            return this.View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.bookService.AddNewBookAsync(model);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.bookService.GetBookByIdForEditAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(All));
            }
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddNewBookViewModel model, int id)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.bookService.EditBookAsync(model, id);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> MyBooks()
        {
            var models = await this.bookService.GetByOwnerBooksAsync(GetUserId());
            return this.View(models);
        }
    }
}
