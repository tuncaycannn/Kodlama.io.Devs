using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
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

        public async Task<Core.Security.Entities.User> GetByEmail(string email)
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

        public async Task<bool> UserExists(string email)
        {
            if (await GetByEmail(email) != null)
            {
                throw new BusinessException("User Exist");
            }

            return true;
        }
    }
}
