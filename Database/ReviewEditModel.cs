using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLibraryManager.Database
{
    
    public class ReviewEditModel
    {

        [Key]
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public double Score { get; set; }
    }
}
