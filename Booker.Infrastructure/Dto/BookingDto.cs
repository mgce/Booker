using System;

namespace Booker.Infrastructure.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }

        public ClientDto Client { get; set; }

        public EmployeeDto Employee { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DateOfTheVisit { get; set; }

        public ServiceDto Service { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
