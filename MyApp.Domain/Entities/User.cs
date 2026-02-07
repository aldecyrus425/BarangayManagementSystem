using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }
        public string RQ { get; set; }
        public string RA { get; set; }

        protected User() { }

        public User(string username, string password, string role, string rq, string ra)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role is required.");

            if (string.IsNullOrWhiteSpace(rq))
                throw new ArgumentException("Reset password question is required.");

            if (string.IsNullOrWhiteSpace(ra))
                throw new ArgumentException("Reset password answer is required.");

            this.Username = username;
            this.HashPassword = password;
            this.Role = role;
            this.RQ = rq;
            this.RA = ra;

        }

        public void UpdateUser(string username, string role, string rq, string ra)
        {

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");


            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role is required.");

            if (string.IsNullOrWhiteSpace(rq))
                throw new ArgumentException("Reset password question is required.");

            if (string.IsNullOrWhiteSpace(ra))
                throw new ArgumentException("Reset password answer is required.");
            
            this.Username = username;
            this.Role = role;
            this.RQ = rq;
            this.RA = ra;
        }
    }
}
