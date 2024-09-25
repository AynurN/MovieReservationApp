namespace MovieReservationApp.MVC.ViewModels.TheaterVMS
{
    public record TheaterGetVM(string Name, string Location, int TotalSeats, int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted);
    
}
