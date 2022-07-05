﻿using HomeLibraryManager.GoogleBooks;
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
        public IEnumerable<Review> GetReviews()
        {
            return databaseContext.Reviews.Include(x => x.Book);
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
        public bool CreateReview(Review review)
        {
            var book = GetBooks().Where(x => x.BookId == review.Book.BookId).FirstOrDefault();
            if (book != null)
            {
                review.Book = book;
                databaseContext.ChangeTracker.Clear();
                databaseContext.Attach(book);
                databaseContext.Add(review);
                databaseContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
