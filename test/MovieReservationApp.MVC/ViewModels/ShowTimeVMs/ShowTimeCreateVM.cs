namespace MovieReservationApp.MVC.ViewModels.ShowTimeVMs
{
    public record ShowTimeCreateVM(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId);
  
}
