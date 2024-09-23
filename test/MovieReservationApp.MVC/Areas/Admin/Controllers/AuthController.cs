using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Areas.ViewModels.UserVMs;
using MovieReservationApp.MVC.Services.Intefaces;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM vm)
        {
            if (!ModelState.IsValid) return View();

            var data = await authService.Login(vm);

            HttpContext.Response.Cookies.Append("token", data.AccessToken, new CookieOptions
            {
                Expires = data.ExpireDate,
                HttpOnly = true
            });

            return RedirectToAction("Index","Home");
        }

        public IActionResult Logout()
        {
            authService.Logout();

            return RedirectToAction("login");
        }
    }
}
