using Application.Features.UserSocialMedia.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMedia.Commands.PassiveUserSocialMedia
{
    public class PassiveUserSocialMediaCommand : IRequest<PassiveUserSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }

        public class PassiveUserSocialMediaCommandHandler : IRequestHandler<PassiveUserSocialMediaCommand, PassiveUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public PassiveUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<PassiveUserSocialMediaDto> Handle(PassiveUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.UserSocialMedia mappedUserSocialMedia = _mapper.Map<Domain.Entities.UserSocialMedia>(request);
                Domain.Entities.UserSocialMedia passiveUserSocialMedia = await _userSocialMediaRepository.UpdateAsync(mappedUserSocialMedia);
                PassiveUserSocialMediaDto mappedpassiveUserSocialMediaDto = _mapper.Map<PassiveUserSocialMediaDto>(passiveUserSocialMedia);

                return mappedpassiveUserSocialMediaDto;
            }
        }
    }
}
