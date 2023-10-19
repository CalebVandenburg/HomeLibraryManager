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
        #region Books
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
        public Book EditBook(BookEditModel bookEdits)
        {
            var book = GetBooks().Where(x => x.BookId == bookEdits.BookID).FirstOrDefault();
            if (book != null)
            {
                book.EditionNotes = bookEdits.EditionNotes;
                book.IsFirstEdition = bookEdits.IsFirstEdition == "on" ? true : false;//bookEdits.IsFirstEdition;
                book.PrintNumber = bookEdits.PrintNumber;
                databaseContext.ChangeTracker.Clear();
                databaseContext.Attach(book).State = EntityState.Modified;
                try
                {
                    databaseContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
                return book;
            }
            return null;
        }
        public bool DeleteBook(int bookID)
        {
            var book = GetBooks().Where(x => x.BookId == bookID).FirstOrDefault();
            if (book != null)
            {
                databaseContext.ChangeTracker.Clear();
                databaseContext.Attach(book).State = EntityState.Deleted;
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteBooks(List<int> bookIDs)
        {
            var books = GetBooks().Where(x => bookIDs.Contains(x.BookId)).ToList();

            if (books != null && books.Count() > 0)
            {
                databaseContext.ChangeTracker.Clear();
                databaseContext.RemoveRange(books);
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #region Reviews
        public IEnumerable<Review> GetReviews()
        {
            return databaseContext.Reviews.Include(x => x.Book);
        }
        public bool CreateReview(Review review)
        {
            var book = GetBooks().Where(x => x.BookId == review.Book.BookId).FirstOrDefault();
            if (book != null)
            {
                databaseContext.ChangeTracker.Clear();
                review.Book = book;
                databaseContext.Attach(book);
                databaseContext.Add(review);
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }
        public Review EditReview(ReviewEditModel reviewEdits)
        {
            var review = GetReviews().Where(x => x.ReviewId == reviewEdits.ReviewId).FirstOrDefault();
            if (review != null)
            {
                review.Title = reviewEdits.Title;
                review.Text = reviewEdits.Text;
                review.Score = reviewEdits.Score;
                databaseContext.ChangeTracker.Clear();
                databaseContext.Attach(review).State = EntityState.Modified;
                try
                {
                    databaseContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
                return review;
            }
            return null;
        }
        public bool DeleteReview(int reviewId)
        {
            var review = GetReviews().Where(x => x.ReviewId == reviewId).FirstOrDefault();
            if (review != null)
            {
                databaseContext.ChangeTracker.Clear();
                databaseContext.Attach(review).State = EntityState.Deleted;
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion



    }
}
