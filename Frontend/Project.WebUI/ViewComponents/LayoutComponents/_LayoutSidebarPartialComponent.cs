using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
