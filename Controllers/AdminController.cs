using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class AdminController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
