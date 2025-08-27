using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.FeatureDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Feature");
            if (pullData.IsSuccessStatusCode)
            {
                var convertString = await pullData.Content.ReadAsStringAsync();
                var convertJson = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(convertString);
                return View(convertJson);
            }
            return View();
        }

        [HttpGet]
        public IActionResult FeatureCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FeatureCreate(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var convertData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent content =  new StringContent(convertData,Encoding.UTF8,"application/json");
            var sendData = await client.PostAsync("https://localhost:7240/api/Feature", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> FeatureDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var deleteData = await client.DeleteAsync($"https://localhost:7240/api/Feature/{id}");
            if (deleteData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
          

        }

        [HttpGet]
        public async Task<IActionResult> FeatureUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var findData = await client.GetAsync($"https://localhost:7240/api/Feature/{id}");
            if (findData.IsSuccessStatusCode)
            {
                var dataString = await findData.Content.ReadAsStringAsync();
                var convertData = JsonConvert.DeserializeObject<UpdateFeatureDto>(dataString);
                return View(convertData);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FeatureUpdate(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var deserializeData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(deserializeData,Encoding.UTF8,"application/json");
            var sendData = await client.PutAsync("https://localhost:7240/api/Feature",stringContent);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
