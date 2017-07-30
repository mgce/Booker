using System;
using Microsoft.AspNet.Identity;

namespace Booker.Infrastructure.Identity
{
    public class IdentityRole : IRole<Guid>
    {
        public IdentityRole()
        {
            this.Id = new Guid();
        }

        public IdentityRole(string name):this()
        {
            Name = name;
        }

        public IdentityRole(string name, Guid id)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; }
        public string Name { get; set; }
    }
}