using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
