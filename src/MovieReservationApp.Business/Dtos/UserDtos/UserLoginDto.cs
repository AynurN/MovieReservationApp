using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos.UserDtos;

public record UserLoginDto(string Username, string Password, bool RememberMe);

