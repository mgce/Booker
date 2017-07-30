using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class Claim
    {
        public virtual int ClaimId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }

        public virtual User User { get; set; }
    }
}
