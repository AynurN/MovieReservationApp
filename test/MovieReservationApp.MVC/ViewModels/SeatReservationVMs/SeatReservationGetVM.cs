namespace MovieReservationApp.MVC.ViewModels.SeatReservationVMs
{
    public record SeatReservationGetVM(string SeatNumber, bool IsBooked, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
   
}
