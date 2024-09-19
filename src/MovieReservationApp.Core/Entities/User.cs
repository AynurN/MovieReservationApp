using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Core.Entities
{
    public class User :IdentityUser
    {
        public string Fullname { get; set; }

        //relational
        public ICollection<Reservation> Reservations { get; set; }
    }
}
