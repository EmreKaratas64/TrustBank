using Microsoft.AspNetCore.Mvc;

namespace TrustBank_PresentationLayer.ViewComponents.Customer
{
    public class CustomerLayoutLeftBarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
