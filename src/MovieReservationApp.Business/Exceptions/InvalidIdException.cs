using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Exceptions
{
    internal class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }
    }
}
