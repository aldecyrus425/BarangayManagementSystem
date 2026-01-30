using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Ordinance
    {
        public int OrdinanceId { get; set; }
        public string OrdinanceNumber { get; set; }
        public string IntroducedBy { get; set; }
        public string Description { get; set; }
        public DateTime DateEnacted { get; set; }
        public string Approved_By { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
