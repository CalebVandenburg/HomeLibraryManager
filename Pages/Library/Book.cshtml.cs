using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeLibraryManager.Database;
using HomeLibraryManager.Models;

namespace HomeLibraryManager.Pages.Library
{
    public class BookModel : PageModel
    {
        private readonly BookRepository bookRepository;

        public BookModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookRepository.GetBooks().Where(x=>x.BookId == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostCollectorAsync([FromForm] BookEditModel bookEdits)
        {
            var bookEdited = bookRepository.EditBook(bookEdits);
            if(bookEdited != null)
            {
                //while i could assign the edited book to Book and just return the page it cause url issues if the user refreshes
                return RedirectToPage("Book", new {id = bookEdits.BookID});
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync([FromForm] BookEditModel bookEdits)
        {
            bool bookEdited = bookRepository.DeleteBook(bookEdits.BookID);
            if (bookEdited)
            {
                //while i could assign the edited book to Book and just return the page it cause url issues if the user refreshes
                return RedirectToPage("/Library/Books");
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
