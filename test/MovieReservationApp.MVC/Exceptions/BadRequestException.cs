namespace MovieReservationApp.MVC.Exceptions
{
    public class BadRequestException : Exception
    {
        public string PropName { get; set; }
        public BadRequestException()
        {
        }

        public BadRequestException(string? message) : base(message)
        {
        }
        public BadRequestException(string propertyName, string? message) : base(message)
        {
            PropName = propertyName;
        }
    }
}
