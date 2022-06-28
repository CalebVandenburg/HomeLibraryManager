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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var bookEdited = bookRepository.EditBook(Book);
            if(bookEdited)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}
