using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Exceptions
{
    public class SeatsAllFullException : Exception
    {
        public SeatsAllFullException()
        {
        }

        public SeatsAllFullException(string? message) : base(message)
        {
        }
    }
}
