using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
