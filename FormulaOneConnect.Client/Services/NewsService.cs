using FormulaOneConnect.Client.Services.Interfaces;
using FormulaOneConnect.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace FormulaOneConnect.Client.Services
{
    public class NewsService : INewsService
    {
        private HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NewsResult> GetAllNews(string search = null)
        {
            var url = "News/AllNews?search=Formula%20One_";
            if (search != null) url += search;

            var newsResult = await _httpClient.GetFromJsonAsync<NewsResult>(url);

            return newsResult;
        }

        public async Task<NewsResult> GetTopStories(string search = null)
        {
            var url = "News/TopStories?search=Formula%20One_";
            if (search != null) url += search;

            var topStoryResult = await _httpClient.GetFromJsonAsync<NewsResult>(url);

            return topStoryResult;
        }
    }
}
