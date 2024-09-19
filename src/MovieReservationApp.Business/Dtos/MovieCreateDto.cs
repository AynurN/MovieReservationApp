using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos
{
    public record MovieCreateDto(string Title, string Desc, int Duration, double Rating, DateTime ReleaseDate, ICollection<string> Genres);
    
}
