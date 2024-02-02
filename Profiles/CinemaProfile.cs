using api_movie.Data.Dtos;
using api_movie.Models;
using AutoMapper;

namespace api_movie.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CinemaDto, CinemaModel>();
            CreateMap<UpdateCinemaDto, CinemaModel>();
            CreateMap<CinemaModel, ReadCinemaDto>();
        }
    }
}
