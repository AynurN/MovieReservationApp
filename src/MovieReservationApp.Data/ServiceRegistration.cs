using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieReservationApp.Core.IRepositories;
using MovieReservationApp.Data.DAL;
using MovieReservationApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Data
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<ISeatReservationRepository, SeatReservationRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            services.AddDbContext<AppDbContext>(opt =>
         opt.UseSqlServer(connectionString)
         );
        }
    }
}
