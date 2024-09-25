namespace MovieReservationApp.MVC.ViewModels.ShowTimeVMs
{
	public record ShowTimeUpdateVM(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId);
	
}
