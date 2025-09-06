using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.MenuTableDto;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CustomerTableList()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();


        }
    }
}
