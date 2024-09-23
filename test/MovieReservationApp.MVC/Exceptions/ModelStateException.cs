using System.Runtime.Serialization;

namespace MovieReservationApp.MVC.Exceptions
{
    public class ModelStateException : Exception
    {
        public string PropName { get; set; }
        public ModelStateException()
        {
        }

        public ModelStateException(string? message) : base(message)
        {
        }
        public ModelStateException(string propName,string? message) : base(message)
        {
            PropName = propName;
        }
    }
}
