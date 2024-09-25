using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Filters;
using MovieReservationApp.MVC.Models;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.MovieVMs;
using MovieReservationApp.MVC.ViewModels.ReservationVMs;
using MovieReservationApp.MVC.ViewModels.SeatReservationVMs;
using MovieReservationApp.MVC.ViewModels.SeatVMs;
using MovieReservationApp.MVC.ViewModels.ShowTimeVMs;
using MovieReservationApp.MVC.ViewModels.TheaterVMS;
using NuGet.Common;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;

namespace MovieReservationApp.MVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly ICrudService crudService;

		public HomeController(ICrudService crudService)
        {
			this.crudService = crudService;
		}
       
			public async Task<IActionResult> Index()
			{
				{
					
					var datas = await crudService.GetAllAsync<List<MovieGetVM>>("/movies");

					return View(datas);
				}
		}

        public async Task<IActionResult> Reserve(int id)
        {
            List<ShowTimeGetVM> need = null;
            try
            {
                var movie = await crudService.GetByIdAsync<MovieGetVM>($"/movies/{id}", id);
                List<ShowTimeGetVM> data = await crudService.GetAllAsync<List<ShowTimeGetVM>>("/showTimes");


                if (movie != null && data != null)
                {
                    need = data.Where(vm => vm.MovieTitle == movie.Title).ToList();
                }


            }
            catch (BadRequestException ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");
            
        }
            catch (ModelNotFoundException ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");
            }

            return View(need);
        }
        
        public async Task<IActionResult> GetSeat(int id)
        {
            List<SeatGetVM> data = null;
            //Request.Cookies.TryGetValue("token", out string token);
            //string userId = null;
            //var handler = new JwtSecurityTokenHandler();
            //if (handler.CanReadToken(token))
            //{
            //    var jwtToken = handler.ReadJwtToken(token);
            //    var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            //    userId = userIdClaim?.Value;
            //}
            //ReservationCreateVM vm = new ReservationCreateVM(userId, id);
            try
            {
                // await  crudService.Create("/reservations/create", vm);
                var theater = await crudService.GetByIdAsync<TheaterGetVM>($"/theaters/{id}", id);
                data = await crudService.GetAllAsync<List<SeatGetVM>>("/seats");
                if (theater != null && data != null)
                {
                    data = data.Where(x => x.TheaterName == theater.Name).ToList();

                }

                    
                
			}
            catch (BadRequestException ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");

            }
            catch (ModelNotFoundException ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
                return View("Error");
            }

            return View(data);
        }
		//public async Task<IActionResult> BookSeat(int id)
  //      {

  //      }


	}
}
