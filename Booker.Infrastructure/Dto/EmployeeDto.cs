using System;
using System.Collections.Generic;

namespace Booker.Infrastructure.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public IEnumerable<BookingDto> Bookings { get; protected set; }
    }
}
