
using MovieReservationApp.MVC.ViewModels.AuthVMs;

namespace MovieReservationApp.MVC.Services.Intefaces
{
    public interface IAuthService
    {
        Task<LoginResponseVM> Login(UserLoginVM vm);
        void Logout();
    }
}
