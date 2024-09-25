namespace MovieReservationApp.MVC.ViewModels.MovieVMs
{
    public record MovieCreateVM(string Title, string Desc, int Duration, double Rating, DateTime ReleaseDate, string Genres);
    
}
