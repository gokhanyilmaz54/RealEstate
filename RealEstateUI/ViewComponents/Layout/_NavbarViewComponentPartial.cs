using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
