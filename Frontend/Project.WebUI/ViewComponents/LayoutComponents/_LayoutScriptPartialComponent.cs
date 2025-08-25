using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
