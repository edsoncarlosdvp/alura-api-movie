using api_movie.Data.Dtos;
using api_movie.Models;
using AutoMapper;

namespace api_movie.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<AdressDto, AdressModel>();
            CreateMap<UpdateAdressDto, AdressModel>();
            CreateMap<AdressModel, ReadAdressDto>();
        }
    }
}
