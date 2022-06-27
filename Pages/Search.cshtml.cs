using HomeLibraryManager.Database;
using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HomeLibraryManager.Pages
{
    [IgnoreAntiforgeryToken]
    public class SearchModel : PageModel
    {
        private DatabaseContext databaseContext;
        private GoogleBooksManager googleBooksManager;
        public SearchModel(DatabaseContext databaseContext, GoogleBooksManager googleBooksManager)
        {
            this.databaseContext = databaseContext;
            this.googleBooksManager = googleBooksManager;
        }
        public void OnGet()
        {

        }
        [BindProperty]
        public GoogleSearchFormModel SearchForm { get; set; }

        public PartialViewResult OnPostSearchAsync()
        {
            var books = googleBooksManager.GetBookSuggestionsBySearch(SearchForm.UserInput, SearchForm.SearchType).Result;
            var partialData = Partial("Partials/_GoogleBooksList", books);
            return partialData;
        }
        public PartialViewResult OnPostAddBookAsync([FromBody] string bookID)
        {
            return null;
        }
    }
}
