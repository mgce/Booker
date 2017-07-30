using System.Threading.Tasks;
using Booker.Core.Domain;

namespace Booker.Core.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
