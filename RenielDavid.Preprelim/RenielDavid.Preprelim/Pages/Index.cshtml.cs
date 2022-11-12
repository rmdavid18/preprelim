using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace RenielDavid.Preprelim.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public NewsData? Data { get; set; }  
        public async Task<IActionResult> OnGet()
        {
            var client = new RestClient("https://saurav.tech/NewsAPI/top-headlines/category/health/in.json");

            var request = new RestRequest("", Method.Get);

            RestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<NewsData>(content);

            return Page();
        }
        public class NewsData
        {
            public List<NewsDetails>? News { get; set; }
            public NewsMain? Main { get; set; }
        }
        public class NewsMain
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public string? URL { get; set; }
            public string? Description { get; set; }
         
        }
       
        public class NewsDetails
        {
           public string Image { get; set; }
            public string Content { get; set; }
        }
        public void OnPost()
        {

        }
    }
}