using HomeLibraryManager.Database;
using HomeLibraryManager.GoogleBooks;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HomeLibraryManager.Pages.Reviews
{
    [IgnoreAntiforgeryToken]
    public class ReviewsModel : PageModel
    {
        private BookRepository bookRepository;
        public ReviewsModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void OnGet()
        {
            var reviews = bookRepository.GetReviews().Where(x=>x.Book.User.UserId == HttpContext?.Session.GetInt32("userId")).ToList();
            if (reviews != null && reviews.Count > 0)
            {
                Reviews = reviews;
            }
        }
        [BindProperty]
        public IList<Review> Reviews { get; set; } = default!;
    }
}
