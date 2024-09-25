using MovieReservationApp.MVC.ViewModels.ReservationVMs;
using MovieReservationApp.MVC.ViewModels.SeatVMs;

namespace MovieReservationApp.MVC.ViewModels.BookSeatVMs
{
    public record BookSeatVM(List<SeatGetVM> seats,List<ReservationGetVM> reservations);
    
}
