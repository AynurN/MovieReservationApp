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
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
