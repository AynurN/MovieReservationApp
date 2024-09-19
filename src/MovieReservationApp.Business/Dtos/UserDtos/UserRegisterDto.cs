using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.UserDtos
{
    public record UserRegisterDto(string FullName, string UserName, string Email, string Password, string ConfirmPassword, string? PhoneNumber);
    //TODO: validation
   
}
