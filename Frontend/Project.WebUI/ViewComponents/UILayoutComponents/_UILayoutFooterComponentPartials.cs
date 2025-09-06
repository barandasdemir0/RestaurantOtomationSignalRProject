using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ContactDtos;

namespace Project.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartials:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartials(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Contact");
            var jsonData = await pullData.Content.ReadAsStringAsync();
            var deserealize = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client2.GetAsync("https://localhost:7240/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values!.Select(x => x.ContactLocation).FirstOrDefault();
            }

            return View(deserealize);
        }
    }
}
