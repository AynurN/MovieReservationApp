﻿using Microsoft.AspNetCore.Mvc;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
