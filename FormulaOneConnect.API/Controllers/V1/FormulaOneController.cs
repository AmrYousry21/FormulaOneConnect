using FormulaOneConnect.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace FormulaOneConnect.API.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormulaOneController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public FormulaOneController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("Drivers")]
        public async Task<IActionResult> GetDrivers([FromQuery] int year)
        {
            var endpoint = $"http://ergast.com/api/f1/{year}/drivers.json";
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(endpoint)
            };

            var result = await _httpClient.SendAsync(request);

            return Ok(await result.Content.ReadAsStringAsync());
        }

        [HttpGet("Standings")]
        public async Task<IActionResult> GetStandingsForYear([FromQuery] int year)
        {
            var endpoint = $"http://ergast.com/api/f1/{year}/driverStandings.json";
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(endpoint)
            };

            var result = await _httpClient.SendAsync(request);

            return Ok(await result.Content.ReadAsStringAsync());
        }

    }
}
