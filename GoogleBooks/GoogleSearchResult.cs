namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleSearchResult
    {
        public string Kind { get; set; }
        public int TotalItems { get; set; }
        public List<Item> Items { get; set; }

    }
    public class Item
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public GoogleBook VolumeInfo { get; set; }
    }
    
}
