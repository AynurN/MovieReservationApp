using AutoMapper;
using MovieReservationApp.Business.Dtos;
using MovieReservationApp.Business.Dtos.TheaterDtos;
using MovieReservationApp.Business.Dtos.UserDtos;
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

            CreateMap<Theater, TheaterCreateDto>().ReverseMap();
            CreateMap<Theater, TheaterGetDto>().ReverseMap();
            CreateMap<Theater, TheaterUpdateDto>().ReverseMap();


        }
    }
}
