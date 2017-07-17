using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class Service
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }

        public Service(string name, decimal price)
        {
            SetName(name);
            SetPrice(price);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Username can not be empty.");
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
            UpdatedAt = DateTime.Now;
        }

        private void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception("Price can not be lower than 0");
            }

            if (Price == price)
            {
                return;
            }
            Price = price;
            UpdatedAt = DateTime.Now;
        }
    }
}
