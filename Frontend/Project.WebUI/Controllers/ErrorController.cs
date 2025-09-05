using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
