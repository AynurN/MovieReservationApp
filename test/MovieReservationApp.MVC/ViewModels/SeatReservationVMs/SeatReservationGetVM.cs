namespace MovieReservationApp.MVC.ViewModels.SeatReservationVMs
{
    public record SeatReservationGetVM(string SeatSeatNumber, bool IsBooked, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted, int? ReservationId);
   
}
