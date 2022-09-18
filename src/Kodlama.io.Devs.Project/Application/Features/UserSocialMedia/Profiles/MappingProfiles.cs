using Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.PassiveUserSocialMedia;
using Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedia.Dtos;
using Application.Features.UserSocialMedia.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.UserSocialMedia.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.UserSocialMedia, CreateUserSocialMediaDto>().ReverseMap();

            CreateMap<Domain.Entities.UserSocialMedia, UpdateUserSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.UserSocialMedia, UpdateUserSocialMediaDto>().ReverseMap();

            CreateMap<Domain.Entities.UserSocialMedia, PassiveUserSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.UserSocialMedia, PassiveUserSocialMediaDto>().ReverseMap();

            CreateMap<Domain.Entities.UserSocialMedia, UserSocialMediaGetByIdDto>().ReverseMap();

            CreateMap<UserSocialMediaListModel, IPaginate<Domain.Entities.UserSocialMedia>>().ReverseMap();
            CreateMap<Domain.Entities.UserSocialMedia, UserSocialMediaListDto>()
              .ForMember(dest => dest.DeveloperFullName, src =>
                  src.MapFrom(c => c.User.FirstName + " " + c.User.LastName)).ReverseMap();
        }
    }
}
