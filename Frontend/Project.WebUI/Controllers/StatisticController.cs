using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
