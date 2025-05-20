using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dao;
using WebApplication1.Entities;
using WebApplication1.Service;

namespace WebApplication1.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookService _service = new BookService();

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _service.Create(Book);

            return RedirectToPage("Index");
        }
    }
}