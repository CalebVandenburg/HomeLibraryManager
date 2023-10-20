using HomeLibraryManager.Database;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeLibraryManager.Helpers;

namespace HomeLibraryManager.Pages.Login
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = default!;
        private readonly BookRepository bookRepository;
        public CreateUserModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void OnGet()
        {
        }// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostCreateUserAsync([FromForm] User userCreateInput)
        {
            //at this point i need to hash the users inpout to see if it matches what is stored since that should be stored hashed
            userCreateInput.Password = UserDataEncryption.EncryptPassword(userCreateInput.Password);
            int user = bookRepository.CreateUser(userCreateInput);
            if(user > 0)
            {
                return Redirect("/");
            }
            else
            {

                return new ContentResult { Content = "Failed to add book to library.", ContentType = "application/json", StatusCode = 100 };
            }
        }
    }
}
