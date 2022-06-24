using static HomeLibraryManager.Models.Enums;

namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleSearchFormModel
    {
        public string UserInput { get; set; } = "";
        public SearchType SearchType { get; set; } = SearchType.Keyword;
    }
}
