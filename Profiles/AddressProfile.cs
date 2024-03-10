using api_movie.Data.Dtos;
using api_movie.Models;
using AutoMapper;

namespace api_movie.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, AddressModel>();
            CreateMap<UpdateAddressDto, AddressModel>();
            CreateMap<AddressModel, ReadAddressDto>();
        }
    }
}
