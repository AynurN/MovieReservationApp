using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MovieReservationApp.Business.Dtos.TokenDtos;
using MovieReservationApp.Business.Dtos.UserDtos;
using MovieReservationApp.Business.Exceptions;
using MovieReservationApp.Business.Services.Interfaces;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Services.Implementations
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;

       

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
       
        }
        public async Task<TokenResponseDto> Login(UserLoginDto dto)
        {
            User appUser = null;
            appUser = await userManager.FindByNameAsync(dto.Username);
            if (appUser == null)
            {
                throw new EntityNotFoundException("User not found!");
            }
            var result = await signInManager.PasswordSignInAsync(appUser, dto.Password, dto.RememberMe, false);
            if (!result.Succeeded)
            {
                throw new UnsuccesfulOperationException("Login unsuccessfull!");

            }
            var roles = await userManager.GetRolesAsync(appUser);
            //token
            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim("FullName", appUser.Fullname),
                .. roles.Select(role => new Claim(ClaimTypes.Role, role))

            ];
            string key = "7537a543-a120-4843-80c9-28e454c0c351";
            DateTime expire = DateTime.UtcNow.AddMinutes(10);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                signingCredentials: signingCredentials,
            claims: claims,
                audience: "https://localhost:7267/",
                issuer: "https://localhost:7267/",
                expires: expire,
                notBefore: DateTime.UtcNow
                );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new TokenResponseDto(token, expire);
        }

        public async Task Register(UserRegisterDto dto)
        {
            User user = mapper.Map<User>(dto);
            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new UnsuccesfulOperationException("Register unsuccessfull!");
            }

        }
    }
   
}
