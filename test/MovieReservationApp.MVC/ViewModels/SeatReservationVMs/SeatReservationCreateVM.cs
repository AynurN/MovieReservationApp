namespace MovieReservationApp.MVC.ViewModels.SeatReservationVMs
{
    public record SeatReservationCreateVM(string SeatNumber, bool IsBooked, int ReservationId);
    
}
