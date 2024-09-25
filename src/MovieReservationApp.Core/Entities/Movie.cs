using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Xml;

namespace MovieReservationApp.Core.Entities
{
    public class Movie :BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genres { get; set; }
        //relational
       public ICollection<ShowTime> ShowTimes { get; set; }

    }
}
