using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.UserSocialMedia.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedia.Commands.CreateUserSocialMedia
{
    public class CreateUserSocialMediaCommand : IRequest<CreateUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }

        public class CreateUserSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreateUserSocialMediaDto>
        {
            private readonly IUserSocialMediaRepository _userSocialMediaRepository;
            private readonly IMapper _mapper;

            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<CreateUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.UserSocialMedia mappedUserSocialMedia = _mapper.Map<Domain.Entities.UserSocialMedia>(request);
                Domain.Entities.UserSocialMedia createUserSocialMedia = await _userSocialMediaRepository.AddAsync(mappedUserSocialMedia);
                CreateUserSocialMediaDto mappedUserSocialMediaDto = _mapper.Map<CreateUserSocialMediaDto>(createUserSocialMedia);

                return mappedUserSocialMediaDto;
            }
        }
    }
}
