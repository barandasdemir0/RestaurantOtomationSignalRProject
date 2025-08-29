using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDtos;

namespace Project.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookAtableComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBookAtableComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Booking");
            var jsonData = await pullData.Content.ReadAsStringAsync();
            var deserealize = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);

            return View(deserealize);
        }
    }
}
