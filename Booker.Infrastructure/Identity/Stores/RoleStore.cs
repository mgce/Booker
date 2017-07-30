using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Booker.Core.Domain;
using Booker.Core.Repositories;
using Microsoft.AspNet.Identity;

namespace Booker.Infrastructure.Identity.Stores
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>, IQueryableRoleStore<IdentityRole, Guid>, IDisposable
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleStore(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(IdentityRole identityRole)
        {
            if (identityRole == null)
                throw new ArgumentNullException(nameof(identityRole));

            var role = GetRole(identityRole);

            _roleRepository.AddAsync(role);
            return _roleRepository.SaveChangesAsync();
        }

        public Task UpdateAsync(IdentityRole identityRole)
        {
            if (identityRole == null)
                throw new ArgumentNullException("role");
            var role = GetRole(identityRole);

            _roleRepository.UpdateAsync(role);
            return _roleRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(IdentityRole identityRole)
        {
            if(identityRole == null)
                throw new ArgumentNullException("role");

            var role = GetRole(identityRole);

            _roleRepository.AddAsync(role);
            return _roleRepository.SaveChangesAsync();
        }

        public Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var role = _roleRepository.GetByIdAsync(roleId).Result;
            return Task.FromResult<IdentityRole>(GetIdentityRoole(role));
        }

        public Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = _roleRepository.GetByName(roleName).Result;
            return Task.FromResult<IdentityRole>(GetIdentityRoole(role));
        }

        public IQueryable<IdentityRole> Roles { get; }

        private Role GetRole(IdentityRole identityRole)
        {
            if (identityRole == null)
                return null;

            return _mapper.Map<Role>(identityRole);
        }

        private IdentityRole GetIdentityRoole(Role role)
        {
            if (role == null)
                return null;

            return _mapper.Map<IdentityRole>(role);
        }
    }
}
