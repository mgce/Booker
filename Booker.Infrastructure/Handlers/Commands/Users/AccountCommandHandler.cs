using System;
using System.Threading.Tasks;
using Booker.Core.Repositories;
using Booker.Infrastructure.Commands;
using Booker.Infrastructure.Commands.Users;
using Booker.Infrastructure.Services;

namespace Booker.Infrastructure.Handlers.Commands.Users
{
    public class AccountCommandHandler :
         ICommandHandler<LoginUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public AccountCommandHandler(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task HandleAsync(LoginUserCommand command)
        { 
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(command.Password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }
    }
}
