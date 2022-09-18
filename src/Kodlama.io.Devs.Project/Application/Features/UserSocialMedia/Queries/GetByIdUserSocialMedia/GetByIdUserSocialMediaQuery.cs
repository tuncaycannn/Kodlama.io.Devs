using Application.Features.UserSocialMedia.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMedia.Queries.GetByIdUserSocialMedia
{
    public class GetByIdUserSocialMediaQuery : IRequest<UserSocialMediaGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdUserSocialMediaQueryHandler : IRequestHandler<GetByIdUserSocialMediaQuery, UserSocialMediaGetByIdDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public GetByIdUserSocialMediaQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }
            public async Task<UserSocialMediaGetByIdDto> Handle(GetByIdUserSocialMediaQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.UserSocialMedia? userSocialMedia = await _userSocialMediaRepository.GetAsync(b => b.Id == request.Id && b.Status == true);

                UserSocialMediaGetByIdDto userSocialMediaGetById = _mapper.Map<UserSocialMediaGetByIdDto>(userSocialMedia);

                return userSocialMediaGetById;
            }
        }
    }
}
