using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Services.Impelementations;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.MovieVMs;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ICrudService crudService;

        public MovieController(ICrudService crudService)
        {
            this.crudService = crudService;
        }
        public async Task<IActionResult> Index()
        {
            {
                if (Request.Cookies["token"] == null)
                {
                    return RedirectToAction("login", "auth");
                }
                var datas = await crudService.GetAllAsync<List<MovieGetVM>>("/movies");

                return View(datas);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            MovieGetVM data = null;
            try
            {
                data = await crudService.GetByIdAsync<MovieGetVM>($"/movies/{id}", id);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateVM vm)
        {
            await crudService.Create("/movies", vm);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await crudService.Delete<object>($"/movies/{id}", id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await crudService.GetByIdAsync<MovieUpdateVM>($"/movies/{id}", id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, MovieUpdateVM vm)
        {
            try
            {
                await crudService.Update($"/movies/{id}", vm);
            }
            catch (ModelStateException ex)
            {
                ModelState.AddModelError(ex.PropName, ex.Message);
                return View();
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

            return RedirectToAction("Index");
        }
    }
}
