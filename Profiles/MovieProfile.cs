using AutoMapper;
using api_movie.Data.Dtos;
using apimovie.Migrations;
using api_movie.Models;

namespace api_movie.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<MovieDto, MovieModel>();
            CreateMap<UpdateMovieDto, MovieModel>();
        }
    }
}
