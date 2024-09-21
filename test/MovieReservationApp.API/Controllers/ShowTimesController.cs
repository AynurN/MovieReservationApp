﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.ShowTimeDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Implementations;
using MovieReservationApp.Business.Services.Interfaces;
using MovieReservationApp.Core.IRepositories;

namespace MovieReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
        private readonly IShowTimeService showTimeService;

        public ShowTimesController(IShowTimeService showTimeService)
        {
            this.showTimeService = showTimeService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var data = await showTimeService.GetByExpessionAsync(true);
            return Ok(new ApiResponse<ICollection<ShowTimeGetDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null,
                Data = data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ShowTimeGetDto dto = null;
            try
            {
                dto = await showTimeService.GetByIdAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<ShowTimeGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest, //400
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<ShowTimeGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ShowTimeGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<ShowTimeGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ShowTimeCreateDto dto)
        {
            try
            {
                await showTimeService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ShowTimeCreateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok(new ApiResponse<ShowTimeCreateDto>
            {
                Data = null,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] ShowTimeUpdateDto dto)
        {
            try
            {
                await showTimeService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<ShowTimeUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id yanlisdir",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<ShowTimeUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ShowTimeUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<ShowTimeUpdateDto>
            {
                Data = null,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await showTimeService.DeleteAsync(id);
            }
            catch (InvalidIdException)
            {
                return BadRequest(new ApiResponse<ShowTimeGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id is invalid!",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<ShowTimeGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ShowTimeGetDto>
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
