using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReservationApp.Business.Dtos.TokenDtos;
using MovieReservationApp.Business.Dtos.UserDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Interfaces;
using MovieReservationApp.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieReservationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AuthsController(IAuthService authService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.authService = authService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register( UserRegisterDto dto)
        {
            try
            {
                await authService.Register(dto);
            }
            catch (UnsuccesfulOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login( UserLoginDto dto)
        {
            TokenResponseDto data = null;
            try
            {
                data = await authService.Login(dto);
            }
            catch (UnsuccesfulOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new ApiResponse<TokenResponseDto>
            {
                Data = data,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
