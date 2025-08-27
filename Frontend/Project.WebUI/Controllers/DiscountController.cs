using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.DiscountDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Discount");
            if (pullData.IsSuccessStatusCode)
            {
                var makeString = await pullData.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(makeString);
                return Ok(jsonConvert);
            }
            return View();
        }

        [HttpGet]
        public IActionResult DiscountCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DiscountCreate(CreateDiscountDto createDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var makeSerialize = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(makeSerialize,Encoding.UTF8,"application/json");
            var sendData = await client.PostAsync("https://localhost:7240/api/Discount", stringContent);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DiscountDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.DeleteAsync($"https://localhost:7240/api/Discount/{id}");
            if (data.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
