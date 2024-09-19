using AutoMapper;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReservationApp.Business
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieGetDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
        }
    }
}
