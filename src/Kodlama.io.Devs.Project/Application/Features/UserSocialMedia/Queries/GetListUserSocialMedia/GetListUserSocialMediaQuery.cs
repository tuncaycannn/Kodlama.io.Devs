using Application.Features.UserSocialMedia.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMedia.Queries.GetListUserSocialMedia
{
    public class GetListUserSocialMediaQuery : IRequest<UserSocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserSocialMediaQueryHandler : IRequestHandler<GetListUserSocialMediaQuery, UserSocialMediaListModel>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<UserSocialMediaListModel> Handle(GetListUserSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.UserSocialMedia> userSocialMedia = await _userSocialMediaRepository.GetListAsync(x => x.Status == true, 
                                                                                                                           index: request.PageRequest.Page, 
                                                                                                                           size: request.PageRequest.PageSize,
                                                                                                                           include: m => m.Include(m => m.User));

                UserSocialMediaListModel mappedUserSocialMediaModel = _mapper.Map<UserSocialMediaListModel>(userSocialMedia);

                return mappedUserSocialMediaModel;
            }
        }
    }
}
