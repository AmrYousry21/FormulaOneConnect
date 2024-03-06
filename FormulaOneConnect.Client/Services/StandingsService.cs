using FormulaOneConnect.Client.Services.Interfaces;
using FormulaOneConnect.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace FormulaOneConnect.Client.Services
{
    public class StandingsService : IStandingsService
    {
        private HttpClient _httpClient { get; set; }

        public StandingsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<StandingResult> GetStandings(int year)
        {
            var standingResult = await _httpClient.GetFromJsonAsync<StandingResult>($"api/FormulaOne/Standings?year={year}");

            return standingResult;
        }
    }
}
