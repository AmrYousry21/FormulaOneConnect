using FormulaOneConnect.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FormulaOneConnect.API.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public NewsController(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    [HttpGet("TopStories")]
    public async Task<IActionResult> GetTopStories()
    {
        var endpoint = "https://api.thenewsapi.com/v1/news/top?";
        var url = new StringBuilder(endpoint);
        var token = _configuration["FormulaOne:NewsAPIToken"];

        url.Append("api_token=" + token + "&");
        url.Append("search=Formula%20One&");
        url.Append("categories=sports&");
        url.Append("search_fields=title%2Cdescription&");
        url.Append("locale=us");

        var result = await _httpClient.GetFromJsonAsync<TopStoryResult>(url.ToString()); 

        return Ok(result);
    }
}
