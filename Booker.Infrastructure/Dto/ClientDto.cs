using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Core.Domain;

namespace Booker.Infrastructure.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<BookingDto> Bookings { get; set; }
    }
}
