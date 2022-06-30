using HomeLibraryManager.Database;
using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HomeLibraryManager.Pages.Google
{
    [IgnoreAntiforgeryToken]
    public class SearchModel : PageModel
    {
        private GoogleBooksManager googleBooksManager;
        private BookRepository bookRepository;
        public SearchModel(BookRepository bookRepository, GoogleBooksManager googleBooksManager)
        {
            this.bookRepository = bookRepository;
            this.googleBooksManager = googleBooksManager;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public GoogleSearchFormModel SearchForm { get; set; }

        public PartialViewResult OnPostSearchAsync()
        {
            var books = googleBooksManager.GetBookSuggestionsBySearch(SearchForm.UserInput, SearchForm.SearchType, SearchForm.CurrentIndex).Result;
            var partialData = Partial("Partials/_GoogleBooksList", books);
            return partialData;
        }
        public ContentResult OnPostAddBookAsync([FromBody] string bookID)
        {
            var googleBook = googleBooksManager.GetBookByID(bookID).Result;
            var added = bookRepository.AddGoogleBookResultToLibrary(googleBook);
            if(added == true)
            {
                return new ContentResult { Content = "Successfully added book to library.", ContentType = "application/json", StatusCode = 200 };
            }
            else
            {
                return new ContentResult { Content = "Failed to add book to library.", ContentType = "application/json", StatusCode = 100 };
            }
        }
    }
}
