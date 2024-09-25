using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.MVC.Exceptions;
using MovieReservationApp.MVC.Services.Intefaces;
using MovieReservationApp.MVC.ViewModels.MovieVMs;
using MovieReservationApp.MVC.ViewModels.ShowTimeVMs;

namespace MovieReservationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowTimeController : Controller
    {
		private readonly ICrudService crudService;

		public ShowTimeController(ICrudService crudService)
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
				var datas = await crudService.GetAllAsync<List<ShowTimeGetVM>>("/showTimes");

				return View(datas);
			}
		}
		public async Task<IActionResult> Detail(int id)
		{
			ShowTimeGetVM data = null;
			try
			{
				data = await crudService.GetByIdAsync<ShowTimeGetVM>($"/showTimes/{id}", id);
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
		public async Task<IActionResult> Create(ShowTimeCreateVM vm)
		{
			await crudService.Create("/showTimes", vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await crudService.Delete<object>($"/showTimes/{id}", id);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			var data = await crudService.GetByIdAsync<ShowTimeUpdateVM>($"/showTimes/{id}", id);

			return View(data);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, ShowTimeUpdateVM vm)
		{
			try
			{
				await crudService.Update($"/showTimes/{id}", vm);
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
