using Application.Features.Auth.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, AccessToken>().ReverseMap();

            CreateMap<LoginedDto, UserForLoginDto>().ReverseMap();
            CreateMap<UserForLoginDto, AccessToken>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();

            CreateMap<RegisteredDto, UserForRegisterDto>().ReverseMap();
            CreateMap<UserForRegisterDto, AccessToken>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}
