using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Models;

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
            };
            return libraryBook;
        }
    }
}
