using HomeLibraryManager.Database;
using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLibraryManager.Pages
{
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

        public JsonResult OnPostSearchAsync()
        {
            var books = googleBooksManager.GetBookSuggestionsBySearch(SearchForm.UserInput, SearchForm.SearchType).Result;
            return new JsonResult(books);
        }
    }
}
