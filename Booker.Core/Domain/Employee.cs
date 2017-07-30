using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Booker.Core.Domain
{
    public class Employee
    {
        [Key]
        public Guid UserId { get; protected set; }

        public ICollection<Booking> Bookings { get; protected set; }

        public Employee(Guid userId)
        {
            UserId = userId;
        }
    }
}
