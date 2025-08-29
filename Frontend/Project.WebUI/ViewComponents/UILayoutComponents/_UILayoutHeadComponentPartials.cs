using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
