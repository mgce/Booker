using AutoMapper;
using Booker.Core.Domain;
using Booker.Core.Repositories;
using Booker.Infrastructure.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Booker.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@gmail.com", "user", "pass");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
            

        }
    }
}
