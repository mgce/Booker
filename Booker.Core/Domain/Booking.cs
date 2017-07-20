using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Booker.Core.Domain
{
    public class Booking
    {
        [Key]
        public Guid Id { get; protected set; }

        public Client Client { get; protected set; }

        public Employee Employee { get; protected set; }

        public Service Service { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime DateOfTheVisit { get; protected set; }      

        public DateTime UpdatedAt { get; protected set; }
    }
}