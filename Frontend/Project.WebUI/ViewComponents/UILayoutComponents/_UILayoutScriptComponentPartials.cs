using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
