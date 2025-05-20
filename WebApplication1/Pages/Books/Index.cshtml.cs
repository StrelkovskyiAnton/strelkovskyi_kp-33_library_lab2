using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entities;
using WebApplication1.Service;

namespace WebApplication1.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookService _service = new BookService();

        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = _service.GetAll();
        }
    }
}
