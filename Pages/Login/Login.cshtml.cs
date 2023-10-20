using HomeLibraryManager.Database;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLibraryManager.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginCredentials LoginCredentials { get; set; } = default!;
        private readonly BookRepository bookRepository;
        public LoginModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void OnGet()
        {
        }// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostLoginAsync([FromForm] LoginCredentials loginCredentials)
        {
            var user = bookRepository.TryLogin(loginCredentials);
            if (user != null)
            {
                HttpContext?.Session.SetInt32("userId", user.UserId);
                HttpContext?.Session.SetString("userFirstName", user.FirstName);
                HttpContext?.Session.SetString("userLastName", user.LastName);
                return Redirect("/");
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
