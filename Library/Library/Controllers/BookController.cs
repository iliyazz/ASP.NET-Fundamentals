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
            var model = await this.bookService.GetAllBooksAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await this.bookService.GetMyBooksAsync(GetUserId());
            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await this.bookService.AddBookToUserAsync(book, userId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await this.bookService.RemoveBookFromUserAsync(book, userId);
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await this.bookService.GetNewBookAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var userId = GetUserId();

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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddBookViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.bookService.EditBookAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        //[HttpGet]
        //public async Task<IActionResult> Cancel()
        //{
        //    //var model = await this.bookService.GetAllBooksAsync();
        //    return  RedirectToAction(nameof(All));
        //}
    }
}
