using System.ComponentModel.DataAnnotations;

namespace HomeLibraryManager.Database
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public List<Book> Books { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
