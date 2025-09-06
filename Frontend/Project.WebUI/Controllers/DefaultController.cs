using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.DtoLayer.ContactDto;
using Project.WebUI.Dtos.MessageDtos;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //var client = _httpClientFactory.CreateClient();
            //var pullData = await client.GetAsync("https://localhost:7240/api/Contact");
            //var jsonData = await pullData.Content.ReadAsStringAsync();
            ////var deserealize = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
            //JsonObject item = jsonobkj
            //ViewBag.location = deserealize!.ContactLocation;

            //HttpClient client = new HttpClient();
            //HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7240/api/Contact");
            //responseMessage.EnsureSuccessStatusCode();
            //string responseBody = await responseMessage.Content.ReadAsStringAsync();
            //JArray item = JArray.Parse(responseBody);
            //string value = item[0]["location"].ToString();
            //ViewBag.location = value;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values!.Select(x => x.ContactLocation).FirstOrDefault();
            }

            return View();
        }

        [HttpGet]
        public PartialViewResult MessageSend()
        {
         

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> MessageSend(CreateMessageDto createMessageDto)
        {

            createMessageDto.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createMessageDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7240/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
