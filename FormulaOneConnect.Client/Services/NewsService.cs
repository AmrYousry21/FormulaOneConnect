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
        public async Task<TopStoryResult> GetTopStories()
        {
            var topStoryResult = await _httpClient.GetFromJsonAsync<TopStoryResult>("News/TopStories");

            return topStoryResult;
        }
    }
}
