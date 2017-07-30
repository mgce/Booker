using System;
using System.Collections.Generic;

namespace Booker.Infrastructure.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}
