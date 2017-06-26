using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Core.Domain;

namespace Booker.Infrastructure.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public IEnumerable<BookingDto> Bookings { get; protected set; }
    }
}
