using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.MovieVMs;
using MovieReservationApp.MVC.ViewModels.SeatVMs;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeatController : Controller
    {
        private readonly ICrudService crudService;

        public SeatController( ICrudService crudService)
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
                var datas = await crudService.GetAllAsync<List<SeatGetVM>>("/seats");

                return View(datas);
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            SeatGetVM data = null;
            try
            {
                data = await crudService.GetByIdAsync<SeatGetVM>($"/seats/{id}", id);
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
        public async Task<IActionResult> Create(SeatCreateVM vm)
        {
            await crudService.Create("/seats", vm);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await crudService.Delete<object>($"/seats/{id}", id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await crudService.GetByIdAsync<SeatUpdateVM>($"/seats/{id}", id);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SeatUpdateVM vm)
        {
            try
            {
                await crudService.Update($"/seats/{id}", vm);
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
