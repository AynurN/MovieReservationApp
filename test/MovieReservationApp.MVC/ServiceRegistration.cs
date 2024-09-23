using MovieReservationApp.MVC.Services.Impelementations;
using MovieReservationApp.MVC.Services.Intefaces;

namespace MovieReservationApp.MVC
{
    public static class ServiceRegistration
    {
        public static void AddRegisterService(this IServiceCollection services) { 
         services.AddScoped<ICrudService, CrudService>();
            services.AddScoped<IAuthService, AuthService>();
        }  
    }
}
