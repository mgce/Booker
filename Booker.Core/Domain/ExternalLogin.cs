using System;

namespace Booker.Core.Domain
{
    public class ExternalLogin
    {
        public Guid Id { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual string LoginProvider { get; set; }

        public virtual string ProviderKey { get; set; }

        public User User { get; set; }

    }
}
