using Microsoft.Extensions.DependencyInjection;
using MovieReservationApp.Business.Services.Implemenations;
using MovieReservationApp.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
