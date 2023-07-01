using Microsoft.AspNetCore.Mvc;

namespace TrustBank_PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public PartialViewResult CustomerLayoutHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutFooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutScriptsPartial()
        {
            return PartialView();
        }
    }
}
