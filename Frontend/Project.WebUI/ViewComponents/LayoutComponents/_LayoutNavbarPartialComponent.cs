using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.WebUI.Dtos.NotificationDto;
using System.Threading.Tasks;

namespace Project.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent:ViewComponent
    {

        //private readonly IHttpClientFactory _httpClientFactory;

        //public _LayoutNavbarPartialComponent(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public IViewComponentResult Invoke()
        {
            //var client =  _httpClientFactory.CreateClient();
            //var pullData = await client.GetAsync("https://localhost:7240/api/Notification/GetAllNotificationsByFalse");
            //if (pullData.IsSuccessStatusCode)
            //{
            //    var convertString = await pullData.Content.ReadAsStringAsync();
            //    var convertJson = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(convertString);
            //    ViewBag.notification = convertJson;
            //}
            //return View();
            return View();
        }
    }
}
