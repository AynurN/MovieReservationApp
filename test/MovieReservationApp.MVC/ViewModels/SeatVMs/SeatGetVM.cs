namespace MovieReservationApp.MVC.ViewModels.SeatVMs
{
	public record SeatGetVM(int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted, string TheaterName, string SeatNumber);
	
}
