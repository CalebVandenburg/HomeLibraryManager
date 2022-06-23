using HomeLibraryManager.Database;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HomeLibraryManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private DatabaseContext databaseContext;

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            _logger = logger;
        }

        public void OnGet()
        {
            var books = databaseContext.Books.ToList();            
        }
    }
}