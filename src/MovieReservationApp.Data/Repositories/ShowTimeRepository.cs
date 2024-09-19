using MovieReservationApp.Core.Entities;
using MovieReservationApp.Core.IRepositories;
using MovieReservationApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Data.Repositories
{
    public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
    {
        public ShowTimeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
