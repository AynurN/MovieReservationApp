namespace MovieReservationApp.MVC.ViewModels.SeatReservationVMs
{
	public record SeatReservationUpdateVM(int SeatId, bool IsBooked, int ReservationId);
	
}
