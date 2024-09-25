using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.Business.Dtos.ReservationDtos;
using MovieReservationApp.Business.Dtos.SeatReservationDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Implementations;
using MovieReservationApp.Business.Services.Interfaces;

namespace MovieReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatReservationsController : ControllerBase
    {
        private readonly ISeatReservationService seatReservationService;

        public SeatReservationsController(ISeatReservationService seatReservationService)
        {
            this.seatReservationService = seatReservationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var data = await seatReservationService.GetByExpessionAsync(true,null,"Seat","Reservation");
            return Ok(new ApiResponse<ICollection<SeatReservationGetDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null,
                Data = data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SeatReservationGetDto dto = null;
            try
            {
                dto = await seatReservationService.GetOneByExpressionAsync(true, null, "Seat", "Reservation");
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest, 
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<SeatReservationGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create( SeatReservationCreateDto dto)
        {
            try
            {
                await seatReservationService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationCreateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok(new ApiResponse<SeatReservationCreateDto>
            {
                Data = null,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  SeatReservationUpdateDto dto)
        {
            try
            {
                await seatReservationService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id yanlisdir",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<SeatReservationUpdateDto>
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
                await seatReservationService.DeleteAsync(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
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
