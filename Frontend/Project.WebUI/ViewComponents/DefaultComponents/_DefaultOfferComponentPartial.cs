using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.DiscountDtos;
using System.Threading.Tasks;

namespace Project.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Discount");
            var convertString = await pullData.Content.ReadAsStringAsync();
            var convertData = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(convertString);
            return View(convertData);
        }
    }
}
