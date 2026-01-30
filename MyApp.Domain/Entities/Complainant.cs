using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Complainant
    {
        public int ComplainantId { get; set; }
        public string ComplainantFirstName { get; set; }
        public string ComplainantLastName { get; set; }
        public int ComplainantAge { get; set; }
        public string ComplainantAddress { get; set; }
        public string ComplainantContact {  get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

    }
}
