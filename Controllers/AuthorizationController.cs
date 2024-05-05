using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetClinic.Domain;
using VetClinic.Domain.Entities;
using VetClinic.Models.Authorization;
using Microsoft.EntityFrameworkCore;

namespace VetClinic.Controllers
{
    public class AuthorizationController : VetClinicBaseController
    {
        private readonly VetClinicContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginAsync([Bind(Prefix = "u")] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new AuthorizationViewModel
                {
                    LoginViewModel = model
                });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

            if (user == null)
            {
                ViewBag.Error = "Некорректные логин и(или) пароль";
                return View("Index", new AuthorizationViewModel
                {
                    LoginViewModel = model
                });
            }

            await AuthenticateAsync(user);
            return RedirectToAction("Index", "Home");
        }

        private async Task AuthenticateAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> RegisterAsync([Bind(Prefix = "r")] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new AuthorizationViewModel
                {
                    RegisterViewModel = model
                });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            if (user != null)
            {
                ViewBag.RegisterError = "Пользователь с таким логином уже существует!";
                return View("Index", new AuthorizationViewModel
                {
                    RegisterViewModel = model
                });
            }

            user = new User(model.Login, model.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            await AuthenticateAsync(user);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
