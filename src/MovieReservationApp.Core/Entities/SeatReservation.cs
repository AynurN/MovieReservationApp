using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class SeatReservation :BaseEntity
    {
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }

        //relational
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
