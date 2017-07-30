using System;
using System.Threading.Tasks;
using Booker.Core.Domain;
using Booker.Core.Repositories;
using Booker.Infrastructure.Commands;
using Booker.Infrastructure.Commands.Users;
using Booker.Infrastructure.Services;

namespace Booker.Infrastructure.Handlers.Commands.Users
{
    class UserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService,
                                 IUserRepository userRepository,
                                 IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _userService = userService;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);
            if (user != null)
            {
                throw new Exception($"User with email: '{command.Email}' already exists.");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(command.Email, command.Password, command.Username, salt);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
