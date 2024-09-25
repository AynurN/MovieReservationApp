using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business.Dtos
{
    public record MovieGetDto(int Id, string Title, DateTime CreatedAt, DateTime ModifiedAt, 
        string Desc,int Duration, double Rating, DateTime ReleaseDate, string Genres, bool IsDeleted  );
   
}
