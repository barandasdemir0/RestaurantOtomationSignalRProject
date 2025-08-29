using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.CategoryDtos;
using Project.WebUI.Dtos.ProductDtos;
using Project.WebUI.Models;

namespace Project.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Product/ProductListWithCategory");
            var convertString = await pullData.Content.ReadAsStringAsync();
            var convertData = JsonConvert.DeserializeObject<List<ResultProductDto>>(convertString);

            //var client2 = _httpClientFactory.CreateClient();
            //var pullData2 = await client2.GetAsync("https://localhost:7240/api/Category");
            //var convertString2 = await pullData2.Content.ReadAsStringAsync();
            //var convertData2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(convertString2);

            //var viewModel = new ProductWithCategoryViewModel
            //{
            //    Categories = convertData2,
            //    Products = convertData,
            //};


            return View(convertData);
        }
    }
}
