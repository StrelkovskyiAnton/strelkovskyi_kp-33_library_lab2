using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dao;
using WebApplication1.Entities;
using WebApplication1.Service;

namespace WebApplication1.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BookService _service = new BookService();

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public int ReaderId { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _service.Get(id);
            if (Book == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPostBorrow(int id)
        {
            Book = _service.Get(Book.book_id);
            if (Book.reader_id != null)
            {
                Message = $" нижка вже позичина читачу {Book.Reader.first_name} {Book.Reader.last_name}, ID: {Book.Reader.reader_id}.";
                return Page();
            }
            bool success = _service.Borrow(Book, ReaderId);
            if (success)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Message = $"„итача з ID {ReaderId} не знайдено.";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostReturnAsync(int id)
        {
            var book = _service.Get(id);
            _service.Return(book);

            return RedirectToPage("./Index");
        }

    }
}
