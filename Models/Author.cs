namespace HomeLibraryManager.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = "N/A";
        public string LastName { get; set; } = "N/A";
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
