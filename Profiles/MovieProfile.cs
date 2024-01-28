using AutoMapper;
using api_movie.Data.Dtos;
using api_movie.Models;

namespace api_movie.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<MovieDto, MovieModel>();
            CreateMap<UpdateMovieDto, MovieModel>();
            CreateMap<MovieModel, UpdateMovieDto>();
            CreateMap<MovieModel, ReadMovieDto>();
        }
    }
}
