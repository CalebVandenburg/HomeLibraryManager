using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Helpers;
using HomeLibraryManager.Models;
using Microsoft.EntityFrameworkCore;

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
        public bool EditBook(Book book)
        {
            databaseContext.ChangeTracker.Clear();
            databaseContext.Attach(book).State = EntityState.Modified;
            try
            {
                databaseContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
