using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthServices;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto loginedDto { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginedDto>
        {
            private readonly AuthBusinessRules _businessRules;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;

            public LoginUserCommandHandler(AuthBusinessRules businessRules, IMapper mapper, IAuthService authService)
            {
                _businessRules = businessRules;
                _mapper = mapper;
                _authService = authService;
            }

            public async Task<LoginedDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _businessRules.VerifyPasswordHash(request.loginedDto.Email, request.loginedDto.Password);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                LoginedDto mappedUser = _mapper.Map<LoginedDto>(createdAccessToken);

                return mappedUser;
            }
        }

    }
}
