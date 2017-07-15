using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booker.Core.Domain;
using Booker.Core.Repositories;

namespace Booker.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BookerContext context) 
            : base(context)
        {
        }
    }
}
