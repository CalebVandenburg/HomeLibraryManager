namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleSearchResult
    {
        public string Kind { get; set; }
        public int TotalItems { get; set; }
        public List<GoogleBookSingleResult> Items { get; set; }
        public int CurrentIndex { get; set; }

    }
    public class GoogleBookSingleResult
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public GoogleBook VolumeInfo { get; set; }
    }
    
}
