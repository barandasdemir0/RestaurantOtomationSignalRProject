using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class ProgressBarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
