using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.WebUI.Dtos.AboutDtos;
using Project.WebUI.Dtos.NotificationDto;
using System.Text;
using System.Threading.Tasks;

namespace Project.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7240/api/Notifications/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> NotificationsChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7240/api/Notifications/NotificationStatusChangeToTrue/{id}");
          
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> NotificationsChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7240/api/Notifications/NotificationStatusChangeToFalse/{id}");
          
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> NotificationsCreate()
        {
            var client = _httpClientFactory.CreateClient();
            var pullData = await client.GetAsync("https://localhost:7240/api/Notifications");
            var jsonData = await pullData.Content.ReadAsStringAsync();
            var convertJson = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);

            var typeValues = convertJson!
                .Select(x => new SelectListItem
                 {
                    Text = (x.Type?.Trim().ToLower()) switch
                        {
                        "notif-icon notif-primary" => "Normal",
                        "notif-icon notif-success" => "Müsait",
                        "notif-icon notif-danger" => "Acil",
                        _ => "Bilinmeyen"
                        },
                    Value = x.Type
                 })
                .GroupBy(x => x.Text)    // Aynı Text’leri grupluyoruz
                .Select(g => g.First())  // İlkini alıyoruz
                .ToList();


            // Icon dropdown
            var iconValues = convertJson!
                .Select(x => new SelectListItem
                {
                    Text = x.Icon switch
                    {
                        "la la-user-plus" => "Rezervasyon",
                        "la la-comment" => "Yorum",
                        "la la-heart" => "Acil",
                        _ => "Bilinmeyen"
                    },
                    Value = x.Icon
                })
                .GroupBy(x => x.Text)
                .Select(g => g.First()) 
                .ToList();

           
            ViewBag.NotificationTypes = typeValues;
            ViewBag.NotificationIcons = iconValues;

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> NotificationsCreate(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Status = true;
            createNotificationDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7240/api/Notifications", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public async Task<IActionResult> NotificationDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var findData = await client.DeleteAsync($"https://localhost:7240/api/Notifications/{id}");
            if (findData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> NotificationsUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7240/api/Notifications/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);



            
                return View(values);
            }

          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NotificationsUpdate(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7240/api/Notifications", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
