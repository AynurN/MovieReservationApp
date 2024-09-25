namespace MovieReservationApp.MVC.ViewModels.ReservationVMs
{
    public record ReservationGetVM(int Id, DateTime CreatedAt, DateTime ModifiedAt, bool IsDeleted, string UserUserName, DateTime ShowTimeStartTime, DateTime ShowTimeEndTime, int ShowTimeId);
    
}
