using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class Role
    {
        private ICollection<User> _users;

        public Guid RoleId { get; set; }
        public string Name { get; set; }
       
        public ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }
    }
}
