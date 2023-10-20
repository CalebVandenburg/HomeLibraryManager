using HomeLibraryManager.Database;
using HomeLibraryManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web.Providers.Entities;

namespace HomeLibraryManager.Pages.Login
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext?.Session.Remove("userId");
            HttpContext?.Session.Remove("userFirstName");
            HttpContext?.Session.Remove("userLastName");
        }
    }
}
