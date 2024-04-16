using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class AccountController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
