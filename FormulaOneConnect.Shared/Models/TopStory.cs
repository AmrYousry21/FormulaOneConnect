
namespace FormulaOneConnect.Shared.Models;

public class TopStoryResult 
{
    public object Meta {  get; set; }
    public List<TopStory> Data { get; set; }
}

public class TopStory
{
    public string Uuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Keywords { get; set; }
    public string Snippet { get; set; }
    public string Url { get; set; }
    public string Image_url { get; set; }
    public string Language { get; set; }
    public DateTime Published_at { get; set; }
    public string Source { get; set; }
    public List<string> Categories { get; set; }
    public object Relevance_score { get; set; }
    public string Locale { get; set; }
}
