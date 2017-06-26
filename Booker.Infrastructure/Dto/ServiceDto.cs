using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Infrastructure.Dto
{
    public class ServiceDto
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }
    }
}
