using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booker.Core.Domain;
using Booker.Core.Repositories;
using Microsoft.AspNet.Identity;
using Claim = System.Security.Claims.Claim;

namespace Booker.Infrastructure.Identity.Stores
{
    public class UserStore : IUserLoginStore<IdentityUser, Guid>
        , IUserClaimStore<IdentityUser, Guid>
        , IUserRoleStore<IdentityUser, Guid>
        , IUserPasswordStore<IdentityUser, Guid>
        , IUserSecurityStampStore<IdentityUser, Guid>
        , IUserStore<IdentityUser, Guid>, IDisposable
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserStore(IUserRepository userRepository,IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }


        public void Dispose()
        {           
        }

        public Task CreateAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));

            var user = GetUser(identityUser);

            _userRepository.AddAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task UpdateAsync(IdentityUser identityUser)
        {
            if(identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if(user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            user = _mapper.Map<User>(identityUser);

            _userRepository.UpdateAsync(user);
            return _userRepository.SaveChangesAsync();

        }

        public Task DeleteAsync(IdentityUser identityUser)
        {
            if(identityUser == null) 
                throw new ArgumentNullException(nameof(identityUser));

            var user = GetUser(identityUser);
            _userRepository.RemoveAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task<IdentityUser> FindByIdAsync(Guid userId)
        {
            var user = _userRepository.GetByIdAsync(userId);
            return Task.FromResult<IdentityUser>(GetIdentityUser(user.Result));
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            var user = _userRepository.GetByUsernameAsync(userName);
            return Task.FromResult<IdentityUser>(GetIdentityUser(user.Result));
        }

        public Task AddLoginAsync(IdentityUser identityUser, UserLoginInfo login)
        {
            if(identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            var externalLogin = new ExternalLogin
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                User = user
            };
            user.Logins.Add(externalLogin);

            _userRepository.UpdateAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task RemoveLoginAsync(IdentityUser identityUser, UserLoginInfo login)
        {
            if (identityUser == null)
                throw new ArgumentNullException("user");
            if (login == null)
                throw new ArgumentNullException("login");

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");

            var externalLogin = user.Logins.FirstOrDefault
                (x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            user.Logins.Remove(externalLogin);

            _userRepository.UpdateAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException("user");

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            return Task.FromResult<IList<UserLoginInfo>>
                (user.Logins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList());
        }

        public Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(IdentityUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            var role = _roleRepository.GetByName(roleName).Result;
            if (role == null)
                throw new ArgumentException("roleName does not correspond to a Role entity.", nameof(roleName));

            user.Roles.Add(role);

            _userRepository.UpdateAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task RemoveFromRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            var role = user.Roles.FirstOrDefault(x => x.Name == roleName);
            user.Roles.Remove(role);

            _userRepository.UpdateAsync(user);
            return _userRepository.SaveChangesAsync();
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            return Task.FromResult<IList<string>>(user.Roles.Select(x => x.Name).ToList());
        }

        public Task<bool> IsInRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");

            var user = _userRepository.GetByIdAsync(identityUser.Id).Result;
            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", nameof(identityUser));

            return Task.FromResult<bool>(user.Roles.Any(x => x.Name == roleName));

        }

        public Task SetPasswordHashAsync(IdentityUser identityUser, string passwordHash)
        {
            identityUser.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            return Task.FromResult<string>(identityUser.Password);
        }

        public Task<bool> HasPasswordAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(identityUser.Password));
        }

        public Task SetSecurityStampAsync(IdentityUser identityUser, string stamp)
        {
            identityUser.Salt = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
                throw new ArgumentNullException(nameof(identityUser));
            return Task.FromResult<string>(identityUser.Salt);
        }

        private User GetUser(IdentityUser identityUser)
        {
            if (identityUser == null)
                return null;

            var user = _mapper.Map<User>(identityUser);

            return user;
        }

        private IdentityUser GetIdentityUser(User user)
        {
            if (user == null)
                return null;

            var identityUser = _mapper.Map<IdentityUser>(user);

            return identityUser;
        }
    }
}