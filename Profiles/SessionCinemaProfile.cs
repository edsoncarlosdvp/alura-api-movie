using api_movie.Data.Dtos;
using api_movie.Models;
using AutoMapper;

namespace api_movie.Profiles
{
    public class SessionCinemaProfile : Profile
    {
        public SessionCinemaProfile()
        {
            CreateMap<SessionCinemaCreateDto, SessionCinemaModel>();
            CreateMap<SessionCinemaModel, SessionCinemaReadDto>();
        }
    }
}
