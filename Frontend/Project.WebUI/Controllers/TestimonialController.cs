using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.TestimonialDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class TestimonialController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Testimonial");
            if (pullData.IsSuccessStatusCode)
            {
                var makeString = await pullData.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(makeString);
                return View(jsonConvert);
            }
            return View();
        }
        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var convertData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent content = new StringContent(convertData,Encoding.UTF8,"application/json");
            var sendData = await client.PostAsync("https://localhost:7240/api/Testimonial", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> TestimonialDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var deleteData = await client.DeleteAsync($"https://localhost:7240/api/Testimonial/{id}");
            if (deleteData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

     

        [HttpGet]
        public async Task<IActionResult> TestimonialUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var findData = await client.GetAsync($"https://localhost:7240/api/SocialMedia/{id}");
            if (findData.IsSuccessStatusCode)
            {
                var dataString = await findData.Content.ReadAsStringAsync();
                var convertData = JsonConvert.DeserializeObject<UpdateTestimonialDto>(dataString);
                return View(convertData);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var deserializeData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent stringContent = new StringContent(deserializeData, Encoding.UTF8, "application/json");
            var sendData = await client.PutAsync("https://localhost:7240/api/SocialMedia", stringContent);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
