using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entities;
using WebApplication1.Service;


namespace WebApplication1.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BookService _service = new BookService();

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _service.Get(id);
            if (Book == null)
                return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _service.Edit(Book);
            return RedirectToPage("Index");
        }
    }
}