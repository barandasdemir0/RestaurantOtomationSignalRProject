using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.BookingDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            createBookingDto.BookingDescription = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var makeSerialize = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(makeSerialize, Encoding.UTF8, "application/json");
            var sendData = await client.PostAsync("https://localhost:7240/api/Booking", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorContent = await sendData.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ValidationProblemDetails>(errorContent);
                foreach (var error in errors.Errors)
                {
                    foreach (var errorMsg in error.Value)
                    {
                        ModelState.AddModelError(error.Key, errorMsg);
                    }
                }

            }

            return View();

        }
    }
}
