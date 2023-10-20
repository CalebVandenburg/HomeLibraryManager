using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeLibraryManager.Database;

namespace HomeLibraryManager.Pages.Reviews
{
    public class ReviewModel : PageModel
    {
        private readonly BookRepository bookRepository;

        public ReviewModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = bookRepository.GetReviews().Where(x => x.ReviewId == id && x.Book.User.UserId == HttpContext?.Session.GetInt32("userId")).FirstOrDefault();
            if (review == null)
            {
                return NotFound();
            }
            Review = review;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostReviewAsync([FromForm] ReviewEditModel reviewEdits)
        {
            var reviewEdited = bookRepository.EditReview(reviewEdits);
            if (reviewEdited != null)
            {
                //while i could assign the edited book to Book and just return the page it cause url issues if the user refreshes
                return RedirectToPage("Review", new { id = reviewEdits.ReviewId });
            }
            else
            {
                return RedirectToPage("Error");
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync([FromForm] ReviewEditModel reviewEdits)
        {
            bool bookEdited = bookRepository.DeleteReview(reviewEdits.ReviewId);
            if (bookEdited)
            {
                //while i could assign the edited book to Book and just return the page it cause url issues if the user refreshes
                return RedirectToPage("/Reviews/Reviews");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
