using System;
using Microsoft.AspNet.Identity;

namespace Booker.Infrastructure.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityUser(string username) : this()
        {
            this.UserName = username;
        }

        public Guid Id { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}