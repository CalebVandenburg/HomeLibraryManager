using System.Net;
using static HomeLibraryManager.Models.Enums;
using Newtonsoft.Json;

namespace HomeLibraryManager.GoogleBooks
{
    public class GoogleBooksManager
    {

        public async Task<string> GetBookSuggestionsBySearch(string search, SearchType searchType)
        {
            var url = "https://www.googleapis.com/books/v1/volumes";
            GoogleSearchResult searchResult = null;
            if(!String.IsNullOrEmpty(search))
            {
                if(searchType == SearchType.Keyword)
                {
                    url = $"{url}?q={search}";
                }
                else
                {
                    url = $"{url}?q=in{searchType.ToString().ToLower()}:{search}";
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
                var result = JsonConvert.DeserializeObject<GoogleSearchResult>(responseBody);
                return responseBody;
            }
            return "";

        }
    }
}
