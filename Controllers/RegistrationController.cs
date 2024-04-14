using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyAction()
        {
            return View();
        }
    }
}
