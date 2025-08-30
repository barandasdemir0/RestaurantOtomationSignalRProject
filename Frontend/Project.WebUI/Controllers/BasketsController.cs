using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.AboutDtos;
using Project.WebUI.Dtos.BasketDtos;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class BasketsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Baskets/GetBasketsByMenuTableWithProductName?id=1");
            if (pullData.IsSuccessStatusCode)
            {
                var convertString = await pullData.Content.ReadAsStringAsync();
                var convertJson = JsonConvert.DeserializeObject<List<ResultBasketDto>>(convertString);
                return View(convertJson);

            }
            return View();
        }
    }
}
