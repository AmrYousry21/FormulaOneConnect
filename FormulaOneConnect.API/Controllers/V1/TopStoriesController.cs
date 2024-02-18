using FormulaOneConnect.Data.Models;
using FormulaOneConnect.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Text;

namespace FormulaOneConnect.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class TopStoriesController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TopStoriesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("TopStories")]
    public IActionResult GetTopStories()
    {
        var endpoint = "https://api.thenewsapi.com/v1/news/top?";
        var url = new StringBuilder();
        var token = _configuration["FormulaOne:NewsAPIToken"];

        url.Append(endpoint);
        url.Append(token + "&");
        url.Append("search=Formula%20One&");
        url.Append("categories=sports&");
        url.Append("search_fields=title%2Cdescription&");
        url.Append("locale=us");
        url.Append("published_after" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));

        return Ok();
    }
}
