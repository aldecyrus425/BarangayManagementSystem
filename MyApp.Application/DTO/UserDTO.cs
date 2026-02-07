using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string RQ { get; set; }
        public string RA { get; set; }

    }

    public class AddUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string RQ { get; set; }
        public string RA { get; set; }
    }

    public class UpdateUserDTO
    {
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }
        public string RQ { get; set; }
        public string RA { get; set; }
    }
}
