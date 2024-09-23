using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Models;
using System.Diagnostics;

namespace MovieReservationApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
