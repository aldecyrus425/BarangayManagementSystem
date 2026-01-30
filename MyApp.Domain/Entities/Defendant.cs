using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Defendant
    {
        public int DefendantId { get; set; }
        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public int DefendantAge { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantContact { get; set; }

        public User User {  get; set; }
        public int UserId { get; set; }
    }
}
