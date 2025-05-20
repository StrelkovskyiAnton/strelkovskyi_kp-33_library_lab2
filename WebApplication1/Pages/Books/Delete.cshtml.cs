using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Dao;
using WebApplication1.Entities;
using WebApplication1.Service;


namespace WebApplication1.Pages.Books
{
    public class DeleteModel : PageModel
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

        public IActionResult OnPost(int id)
        {
            _service.Remove(id);
            return RedirectToPage("Index");
        }
    }
}