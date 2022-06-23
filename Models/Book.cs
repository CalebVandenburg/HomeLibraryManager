using System.ComponentModel.DataAnnotations;

namespace HomeLibraryManager.Models
{
    
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; } = "N/A";
        public Author Author { get; set; } = new Author();
    }
}
