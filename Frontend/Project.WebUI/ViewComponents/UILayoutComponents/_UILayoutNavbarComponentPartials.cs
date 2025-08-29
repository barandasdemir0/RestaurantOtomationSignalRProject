using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
