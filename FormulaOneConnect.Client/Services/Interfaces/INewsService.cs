using FormulaOneConnect.Shared.Models;

namespace FormulaOneConnect.Client.Services.Interfaces
{
    public interface INewsService
    {
        Task<NewsResult> GetTopStories(string search = null);
        Task<NewsResult> GetAllNews(string search = null);
    }
}
