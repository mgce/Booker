using Booker.Core.Domain;
using System.Threading.Tasks;

namespace Booker.Core.Repositories
{
    public interface IUserRepository 
        : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
    }
}
