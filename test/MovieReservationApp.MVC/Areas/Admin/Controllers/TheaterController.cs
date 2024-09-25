using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.MovieVMs;
using MovieReservationApp.MVC.ViewModels.TheaterVMS;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheaterController : Controller
    {
        private readonly ICrudService crudService;

        public TheaterController(ICrudService crudService)
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
                var datas = await crudService.GetAllAsync<List<TheaterGetVM>>("/theaters");

                return View(datas);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            TheaterGetVM data = null;
            try
            {
                data = await crudService.GetByIdAsync<TheaterGetVM>($"/theaters/{id}", id);
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
        public async Task<IActionResult> Create(TheaterCreateVM vm)
        {
            await crudService.Create("/theaters", vm);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await crudService.Delete<object>($"/theaters/{id}", id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await crudService.GetByIdAsync<TheaterUpdateVM>($"/theaters/{id}", id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TheaterUpdateVM vm)
        {
            try
            {
                await crudService.Update($"/theaters/{id}", vm);
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
