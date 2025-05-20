using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string genre { get; set; }
        [Required]
        public string author_last_name { get; set; }
        [Required]
        public string author_first_name { get; set; }

        public int? reader_id { get; set; }
        [ForeignKey("reader_id")]
        public virtual Reader? Reader { get; set; }
    }
}
