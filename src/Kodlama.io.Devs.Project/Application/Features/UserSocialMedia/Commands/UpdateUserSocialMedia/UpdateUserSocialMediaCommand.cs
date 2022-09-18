using Application.Features.UserSocialMedia.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMedia.Commands.UpdateUserSocialMedia
{
    public class UpdateUserSocialMediaCommand : IRequest<UpdateUserSocialMediaDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }

        public class UpdateUserSocialMediaCommandHandler : IRequestHandler<UpdateUserSocialMediaCommand, UpdateUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public UpdateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<UpdateUserSocialMediaDto> Handle(UpdateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.UserSocialMedia mappedUserSocialMedia = _mapper.Map<Domain.Entities.UserSocialMedia>(request);
                Domain.Entities.UserSocialMedia updatePUserSocialMedia = await _userSocialMediaRepository.UpdateAsync(mappedUserSocialMedia);
                UpdateUserSocialMediaDto mappedUpdateUserSocialMediaDto = _mapper.Map<UpdateUserSocialMediaDto>(updatePUserSocialMedia);

                return mappedUpdateUserSocialMediaDto;
            }
        }
    }
}
