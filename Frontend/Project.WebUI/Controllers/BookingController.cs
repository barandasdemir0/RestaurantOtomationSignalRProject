using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BusinessLayer.Abstract;
using Project.WebUI.Dtos.BookingDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Booking");
            if (pullData.IsSuccessStatusCode)
            {
                var makeString = await pullData.Content.ReadAsStringAsync();
                var deserelizeObject = JsonConvert.DeserializeObject<List<ResultBookingDto>>(makeString);
                return View(deserelizeObject);
            }


            return View();
        }


        [HttpGet]
        public IActionResult BookingCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingCreate(CreateBookingDto createBookingDto)
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

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> BookingDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.DeleteAsync($"https://localhost:7240/api/Booking/{id}");
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BookingUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var getData = await client.GetAsync($"https://localhost:7240/api/Booking/{id}");
            if (getData.IsSuccessStatusCode)
            {
                var serializeString = await getData.Content.ReadAsStringAsync();
                var serializeData = JsonConvert.DeserializeObject<UpdateBookingDto>(serializeString);
                return View(serializeData);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            updateBookingDto.BookingDescription = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var serializeObject = JsonConvert.SerializeObject(updateBookingDto);
            StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
            var sendData = await client.PutAsync("https://localhost:7240/api/Booking", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();

        }




        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7240/api/Booking/BookingStatusApproved/{id}");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> BookingStatusCanceled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7240/api/Booking/BookingStatusCanceled/{id}");
            return RedirectToAction("Index");
        }

    }
}
