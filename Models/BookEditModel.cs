namespace HomeLibraryManager.Models
{
    public class BookEditModel
    {
        public int BookID { get; set; }
        public string? PrintNumber { get; set; }
        public string? EditionNotes { get; set; }
        public string? IsFirstEdition { get; set; }
    }
}
