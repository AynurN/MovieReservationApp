namespace MovieReservationApp.MVC.ViewModels.ShowTimeVMs
{
	public record ShowTimeGetVM(DateTime StartTime, DateTime EndTime, string MovieTitle, string TheaterName, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
	
}
