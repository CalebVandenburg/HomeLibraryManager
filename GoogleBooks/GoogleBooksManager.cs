using System.Net;
using static HomeLibraryManager.Models.Enums;
using Newtonsoft.Json;

namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleBooksManager
    {

        public async Task<GoogleSearchResult> GetBookSuggestionsBySearch(string search, SearchType searchType)
        {
            var url = "https://www.googleapis.com/books/v1/volumes";
            GoogleSearchResult searchResult = null;
            if (!String.IsNullOrEmpty(search))
            {
                if (searchType == SearchType.Keyword)
                {
                    url = $"{url}?q={search}";
                }
                else if (searchType == SearchType.Title || searchType == SearchType.Author || searchType == SearchType.Publisher)
                {
                    url = $"{url}?q=in{searchType.ToString().ToLower()}:{search}";
                }
                else
                {
                    url = $"{url}?q={searchType.ToString().ToLower()}:{search}";

                }

                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                searchResult = JsonConvert.DeserializeObject<GoogleSearchResult>(responseBody);
                return searchResult;
            }
            else
            {
                return searchResult;
            }

        }
        public async Task<GoogleBookSingleResult> GetBookByID(string bookID)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes/{bookID}";
            GoogleBookSingleResult searchResult = null;
            if (!String.IsNullOrEmpty(bookID))
            {
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                searchResult = JsonConvert.DeserializeObject<GoogleBookSingleResult>(responseBody);
                return searchResult;
            }
            else
            {
                return searchResult;
            }
        }
    }
}
