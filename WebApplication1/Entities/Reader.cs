using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Reader
    {
        [Key]
        public int reader_id { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string first_name { get; set; }

        public virtual List<Book> BorrowedBooks { get; set; }
    }
}
