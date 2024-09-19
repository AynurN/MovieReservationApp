using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class Reservation :BaseEntity
    {
        public DateTime ReservationDate { get; set; }

        //relational
        public string UserId { get; set; }
        public User User { get; set; }
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }
        public ICollection<SeatReservation> SeatReservations { get; set; }
    }
}
