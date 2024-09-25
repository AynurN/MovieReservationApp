using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class SeatReservation :BaseEntity
    {
        public bool IsBooked { get; set; }

        //relational
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
