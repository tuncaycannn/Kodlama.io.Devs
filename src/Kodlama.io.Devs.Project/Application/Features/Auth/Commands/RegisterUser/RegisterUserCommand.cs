using Application.Features.Auth.Commands.LoginUser;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RegisteredDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserExists(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User user = _mapper.Map<User>(request);
                User registerUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(registerUser);

                RegisteredDto registered = _mapper.Map<RegisteredDto>(createdAccessToken);

                return registered;

            }
        }
    }
}
