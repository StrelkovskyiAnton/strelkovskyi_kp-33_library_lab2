using WebApplication1.Dao;
using WebApplication1.Entities;

namespace WebApplication1.Service
{
    public class BookService
    {
        private readonly BookDao _bookDao = new BookDao();
        private readonly ReaderDao _readerDao = new ReaderDao();

        public List<Book> GetAll() => _bookDao.GetAll();
        public Book Get(int id) => _bookDao.GetById(id);
        public void Create(Book book) => _bookDao.Add(book);
        public void Edit(Book book) => _bookDao.Update(book);
        public void Remove(int id) => _bookDao.Delete(id);

        public bool Borrow(Book book, int readerId)
        {
            if(_readerDao.ReaderExists(readerId))
            {
                book.reader_id = readerId;
                _bookDao.Update(book);
                return true;
            }
            return false;
        }

        public void Return(Book book)
        {
            book.reader_id = null;
            _bookDao.Update(book);
        }
    }
}
