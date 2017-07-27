using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Booker.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        [Key]
        public Guid Id { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string Username { get; protected set; }

        public string FullName { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public virtual ICollection<Claim> Claims { get; set; }

        public virtual ICollection<ExternalLogin> Logins { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        protected User()
        {           
        }

        public User(string email, string password, string username, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetPassword(password, salt);
            SetUsername(username);
            Salt = salt;
            CreatedAt = DateTime.Now;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (Email == email)
            {
                return;
            }
            Email = email;
            UpdatedAt = DateTime.Now;
        }

        private void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username can not be empty.");
            }
            if (Username == username)
            {
                return;
            }
            Username = username;
            UpdatedAt = DateTime.Now;
        }

        private void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }

            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.Now;
        }

    }
}
