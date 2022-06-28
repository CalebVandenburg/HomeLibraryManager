using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Helpers;
using HomeLibraryManager.Models;

namespace HomeLibraryManager.Database
{
    public class BookRepository
    {
        private DatabaseContext databaseContext;
        public BookRepository()
        {
            databaseContext = new DatabaseContext();
        }
        public bool AddGoogleBookResultToLibrary(GoogleBookSingleResult googleBook)
        {
            GoogleToLibrary googleToLibraryHelper = new GoogleToLibrary();
            Book libraryBook = googleToLibraryHelper.ConvertGoogleBookResultToLibraryBook(googleBook);
            databaseContext.Books.Add(libraryBook);
            var numberOfInserts = databaseContext.SaveChanges();
            return numberOfInserts > 0 ? true : false;
        }
        public IEnumerable<Book> GetBooks()
        {
            return databaseContext.Books;
        }
    }
}
