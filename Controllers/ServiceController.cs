using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class ServiceController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
