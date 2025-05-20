using WebApplication1.Entities;

namespace WebApplication1.Dao
{
    public class ReaderDao
    {
        private LibraryContext _context = new LibraryContext();
        public bool ReaderExists(int id)
        {
            if(_context.readers.Find(id) == null) return false;
            return true;
        }
    }
}
