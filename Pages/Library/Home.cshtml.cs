using System;
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
    public class HomeModel : PageModel
    {
        private BookRepository bookRepository;

        public HomeModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        public void OnGet()
        {
        }
    }
}
