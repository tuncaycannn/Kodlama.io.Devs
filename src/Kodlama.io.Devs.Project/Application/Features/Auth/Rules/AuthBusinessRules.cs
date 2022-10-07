using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDublicateWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exist!");
        }

        public async Task<User> GetByEmail(string email)
        {
            var result = await _userRepository.GetAsync(b => b.Email == email);

            if (result == null)
            {
                throw new BusinessException("User Not Found");
            }

            return result;
        }

        public async Task<Core.Security.Entities.User> VerifyPasswordHash(string email, string password)
        {
            Core.Security.Entities.User user = await GetByEmail(email);

            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessException("Password Wrong");
            }
            return user;
        }

    }
}
