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
    public class SeatReservationRepository : GenericRepository<SeatReservation>, ISeatReservationRepository
    {
        public SeatReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
