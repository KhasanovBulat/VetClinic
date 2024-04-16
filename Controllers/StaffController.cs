using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class StaffController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
