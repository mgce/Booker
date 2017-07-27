using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class ExternalLogin
    {

        public virtual Guid UserId { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }

        public User User { get; set; }

    }
}
