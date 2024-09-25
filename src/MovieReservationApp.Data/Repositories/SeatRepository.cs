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
	public class SeatRepository : GenericRepository<Seat>, ISeatRepository
	{
		public SeatRepository(AppDbContext context) : base(context)
		{
		}
	}
}
