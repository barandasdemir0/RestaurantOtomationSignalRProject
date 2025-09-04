using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.MessageDtos;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class DefaultController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
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
