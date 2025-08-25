using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
