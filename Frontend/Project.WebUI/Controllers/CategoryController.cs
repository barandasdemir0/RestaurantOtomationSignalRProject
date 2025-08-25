using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
