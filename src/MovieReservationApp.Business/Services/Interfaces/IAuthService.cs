using Microsoft.AspNetCore.Identity;
using MovieReservationApp.Business.Dtos.TokenDtos;
using MovieReservationApp.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(UserRegisterDto dto);
        Task<TokenResponseDto> Login(UserLoginDto dto);
    }
}
