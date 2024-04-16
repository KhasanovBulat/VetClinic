using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class AppointmentController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
