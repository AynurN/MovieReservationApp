using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Services.Interfaces;

namespace MovieReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MoviesController( IMovieService movieService)
        {
            this.movieService = movieService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll() {
            var data = await movieService.GetByExpessionAsync(true);
            return Ok(new ApiResponse<ICollection<MovieGetDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null,
                Data = data
            });
        }
        


    }
}
