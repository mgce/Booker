using System;
using System.Collections.Generic;

namespace Booker.Core.Domain
{
    public class Client
    {
        public Guid UserId { get; protected set; } 

        public IEnumerable<Booking> Bookings { get; protected set; }

        public Client(Guid userId)
        {
            UserId = userId;
        }
    }
}