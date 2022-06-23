using System.ComponentModel.DataAnnotations;

namespace HomeLibraryManager.Models
{
    
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; } = "N/A";
        public string Publisher { get; set; } = "N/A";
        public int Pages { get; set; }

        public int ISBN10 { get; set; }
        public int ISBN13 { get; set; }
        public Author Author { get; set; } = new Author();
    }
}
