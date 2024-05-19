using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    [Authorize]
    public class AccountController : VetClinicBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
