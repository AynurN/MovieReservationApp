namespace MovieReservationApp.MVC.ViewModels.MovieVMs
{
    public record MovieGetVM(int Id, string Title, DateTime CreatedAt, DateTime ModifiedAt,
        string Desc, int Duration, double Rating, DateTime ReleaseDate, string Genres, bool IsDeleted);
    
}
