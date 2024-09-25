using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.Business.Dtos.SeatDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Interfaces;

namespace MovieReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService seatService;

        public SeatsController(ISeatService seatService)
        {
            this.seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await seatService.GetByExpessionAsync(true, null, "Theater");
            return Ok(new ApiResponse<ICollection<SeatGetDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null,
                Data = data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SeatGetDto dto = null;
            try
            {
                dto = await seatService.GetOneByExpressionAsync(true, null, "Theater");
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<SeatGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<SeatGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(SeatCreateDto dto)
        {
            try
            {
                await seatService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatCreateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok(new ApiResponse<SeatCreateDto>
            {
                Data = null,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SeatUpdateDto dto)
        {
            try
            {
                await seatService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<SeatUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id yanlisdir",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<SeatUpdateDto>
            {
                Data = null,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await seatService.DeleteAsync(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<SeatGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status200OK,
                Data = null,
                ErrorMessage = null
            });
        }
    }
}
