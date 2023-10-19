using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Database;
using System.Linq;

namespace HomeLibraryManager.Helpers
{
    public class GoogleToLibrary
    {
        public Book ConvertGoogleBookResultToLibraryBook(GoogleBookSingleResult googleBook)
        {
            var libraryBook = new Book
            {
                GoogleBookId = googleBook.ID,
                Title = googleBook.VolumeInfo.Title,
                Authors = String.Join(", ", googleBook.VolumeInfo.Authors),
                Description = googleBook.VolumeInfo.Description,
                PublishedDate = googleBook.VolumeInfo.PublishedDate,
                Publisher = googleBook.VolumeInfo.Publisher,
                PageCount = googleBook.VolumeInfo.PageCount,
                Thumbnail = googleBook.VolumeInfo.ImageLinks.Thumbnail,
                SmallThumbnail = googleBook.VolumeInfo.ImageLinks.SmallThumbnail,
                Small = googleBook.VolumeInfo.ImageLinks.Small,
                Large = googleBook.VolumeInfo.ImageLinks.Large,
                Medium = googleBook.VolumeInfo.ImageLinks.Medium,
                ISBN10 = googleBook.VolumeInfo.IndustryIdentifiers.Where(x => x.Type == "ISBN_10").FirstOrDefault()?.Identifier,
                ISBN13 = googleBook.VolumeInfo.IndustryIdentifiers.Where(x => x.Type == "ISBN_13").FirstOrDefault()?.Identifier,
            };
            return libraryBook;
        }
    }
}
