using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.SocialMediaDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/SocialMedia");
            if (pullData.IsSuccessStatusCode)
            {
                var convertString = await pullData.Content.ReadAsStringAsync();
                var convertJson = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(convertString);
                return View(convertJson);
            }
            return View();
        }

        [HttpGet]
        public IActionResult SocialMediaCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var convertJson = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent content = new StringContent(convertJson,Encoding.UTF8,"application/json");
            var sendData = await client.PostAsync("https://localhost:7240/api/SocialMedia", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> SocialMediaDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var deleteData = await client.DeleteAsync($"https://localhost:7240/api/SocialMedia/{id}");
            if (deleteData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
