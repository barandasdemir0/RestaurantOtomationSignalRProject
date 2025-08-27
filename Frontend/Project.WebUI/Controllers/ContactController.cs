using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.ContactDtos;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Contact");
            if (pullData.IsSuccessStatusCode)
            {
                var convertString = await pullData.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultContactDto>>(convertString);
                return View(jsonConvert);
            }



            return View();
        }



        [HttpGet]
        public IActionResult ContactCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactCreate(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var makeSerialize = JsonConvert.SerializeObject(createContactDto);
            StringContent content = new StringContent(makeSerialize, Encoding.UTF8, "application/json");
            var sendData = await client.PutAsync("https://localhost:7240/api/Contact", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> ContactDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var data = await client.DeleteAsync($"https://localhost:7240/api/Contact/{id}");
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ContactUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var findData = await client.GetAsync($"https://localhost:7240/api/Contact/{id}");
            if (findData.IsSuccessStatusCode)
            {
                var convertString = await findData.Content.ReadAsStringAsync();
                var convertData = JsonConvert.DeserializeObject<UpdateContactDto>(convertString);
                return View(convertData);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUpdate(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var serializeData = JsonConvert.SerializeObject(updateContactDto);
            StringContent content = new StringContent(serializeData,Encoding.UTF8,"application/json");
            var sendData = await client.PutAsync("https://localhost:7240/api/Contact/", content);
            if (sendData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
