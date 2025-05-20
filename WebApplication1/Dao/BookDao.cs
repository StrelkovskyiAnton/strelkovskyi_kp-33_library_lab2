using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Dao
{
    public class BookDao
    {
        private LibraryContext _context = new LibraryContext();
        public List<Book> GetAll()
        {
            return _context.books.Include(b => b.Reader).ToList();
        }
        public Book GetById(int id)
        {
            return _context.books.Include(b => b.Reader).FirstOrDefault(b => b.book_id == id);
        }
        public void Add(Book book)
        {
            _context.books.Add(book);
            _context.SaveChanges();
        }
        public void Update(Book book)
        {
            Book existing = GetById(book.book_id);
            existing.title = book.title;
            existing.genre = book.genre;
            existing.author_first_name = book.author_first_name;
            existing.author_last_name = book.author_last_name;
            existing.reader_id = book.reader_id;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.books.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
