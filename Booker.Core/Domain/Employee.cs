using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class Employee
    {
        public Guid UserId { get; protected set; }

        public ICollection<Booking> Bookings { get; protected set; }

        public Employee(Guid userId)
        {
            UserId = userId;
        }
    }
}
