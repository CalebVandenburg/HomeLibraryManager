using System.ComponentModel.DataAnnotations;

namespace HomeLibraryManager.Database
{
    
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? GoogleBookId { get; set; }
        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public string? PrintNumber { get; set; }
        public string? EditionNotes { get; set; }
        public bool? IsFirstEdition { get; set; }
        public string? ISBN10 { get; set; }
        public string? ISBN13 { get; set; }
        public string? Authors { get; set; }
        public string? Description { get; set; }
        public string? PublishedDate { get; set; }
        public int? PageCount { get; set; }
        public string? SmallThumbnail { get; set; }
        public string? Thumbnail { get; set; }
        public string? Small { get; set; }
        public string? Medium { get; set; }
        public string? Large { get; set; }
        public List<Review> Reviews { get; set; }
        public User User { get; set; }
    }
}
