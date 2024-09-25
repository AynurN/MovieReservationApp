using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class Theater :BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }
        

        //relational
        public ICollection<ShowTime> ShowTimes { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
