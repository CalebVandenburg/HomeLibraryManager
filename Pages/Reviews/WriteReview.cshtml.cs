using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HomeLibraryManager.Database;

namespace HomeLibraryManager.Pages.Reviews
{
    public class WriteReviewModel : PageModel
    {
        private readonly BookRepository bookRepository;

        public WriteReviewModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult OnGet(int bookID)
        {
            if(bookID != 0)
            {
                Review = new Review();
                Review.Book = bookRepository.GetBooks().Where(x => x.BookId == bookID).FirstOrDefault();
                return Page();
            } 
            else
            {
                return RedirectToPage("./Index");
            }
        }

        [BindProperty]
        public Review Review { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostReviewAsync([FromForm] Review review)
        {
            var bookCreated = bookRepository.CreateReview(review);
            if(bookCreated)
            {
                return Redirect("/Reviews");
            }
            else
            {
                return Redirect("/Error");
            }
        }
    }
}
