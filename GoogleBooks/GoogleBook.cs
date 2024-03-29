﻿namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleBook
    {
        public string Title { get; set; } = "";
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public int PageCount { get; set; }

        public List<IndustryIdentifier> IndustryIdentifiers { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }
    public class IndustryIdentifier
    {
        public string Type { get; set; } = "";
        public string Identifier { get; set; } = "";
    }
    public class ImageLinks
    {
        public string SmallThumbnail { get; set; }
        public string Thumbnail { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}
