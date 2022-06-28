﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HomeLibraryManager.Database;
using HomeLibraryManager.Models;

namespace HomeLibraryManager.Pages.Library
{
    public class BooksModel : PageModel
    {
        private BookRepository bookRepository;

        public BooksModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IList<Book> Books { get;set; } = default!;

        public void OnGet()
        {
            var books = bookRepository.GetBooks().ToList();
            if (books != null && books.Count > 0)
            {
                Books = books;
            }
        }
    }
}