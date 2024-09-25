using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class Seat :BaseEntity
    {
        public string  SeatNumber { get; set; }

        //relational 
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
        public ICollection<SeatReservation> SeatReservations { get; set; }
    }
}
