using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
