using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.FeatureDtos;
using System.Threading.Tasks;

namespace Project.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    { 

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Feature");
            var jsonData = await pullData.Content.ReadAsStringAsync();
            var deserealize = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

            return View(deserealize);
        }
    }
}
