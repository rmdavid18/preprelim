using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace RenielDavid.Preprelim.Pages
{
    public class FormModel : PageModel
    {
        public WeatherData? Data { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var client = new RestClient("https://fcc-weather-api.glitch.me/api/");

            var request = new RestRequest("", Method.Get);

            RestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<WeatherData>(content);

            return Page();
        }
        public class WeatherData
        {
            public List<WeatherDetails>? Weather { get; set; }
            public WeatherMain? Main { get; set; }
        }
        public class WeatherMain
        {
            public string? Temp { get; set; }
            public string? FeelsLike { get; set; }
            public string? Humidity { get; set; }
            public string? Pressure { get; set; }

        }

        public class WeatherDetails
        {
            public string? Main { get; set; }
            public string? Description { get; set; }
            public string? Icon { get; set; }
        }

        public class TankDetails
        {
            public string? Name { get; set; }
            public string? Armament { get; set; }
            public string? TopSpeed { get; set; }
            public string? Crew { get; set; }
            public string? ArmorType { get; set; }
        }
        public void OnPost()
        {

        }
    }
}

