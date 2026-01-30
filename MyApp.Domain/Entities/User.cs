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
    }
}
