using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class AuthorizationController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
