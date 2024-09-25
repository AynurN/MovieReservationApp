using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Exceptions
{
    public class SeatIsFullException : Exception
    {
        public SeatIsFullException()
        {
        }

        public SeatIsFullException(string? message) : base(message)
        {
        }
    }
}
