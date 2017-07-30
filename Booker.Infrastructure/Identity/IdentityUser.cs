using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Booker.Infrastructure.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid();
        }

        public IdentityUser(string username) : this()
        {
            UserName = username;
        }

        public Guid Id { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }

        public ICollection<IdentityUserLogin> Logins { get; set; }
    }
}