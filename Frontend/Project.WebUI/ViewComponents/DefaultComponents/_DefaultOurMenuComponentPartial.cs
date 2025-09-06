using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.CategoryDtos;
using Project.WebUI.Dtos.ProductDtos;
using Project.WebUI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Product/GetLast6Products");
            var convertString = await pullData.Content.ReadAsStringAsync();
            var convertData = JsonConvert.DeserializeObject<List<ResultProductDto>>(convertString);

            var client2 = _httpClientFactory.CreateClient();
            var pullData2 = await client2.GetAsync("https://localhost:7240/api/Category");
            var convertString2 = await pullData2.Content.ReadAsStringAsync();
            var convertData2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(convertString2);

            var viewModel = new ProductWithCategoryViewModel
            {
                Categories = convertData2,
                Products = convertData,
            };


            return View(viewModel);
        }
    }
}
