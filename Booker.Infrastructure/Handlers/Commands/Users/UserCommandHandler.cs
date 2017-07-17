﻿using System.Threading.Tasks;
using Booker.Infrastructure.Commands;
using Booker.Infrastructure.Commands.Users;
using Booker.Infrastructure.Services;

namespace Booker.Infrastructure.Handlers.Commands.Users
{
    class UserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public UserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            await _userService.RegisterAsync(command.Email, command.Username, command.Password);
        }
    }
}
