using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Blotter
    {
        public int BlotterId { get; set; }
        public DateTime BlotterDate { get; set; } = DateTime.Now;
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }
        
        public Complainant Complainant { get; set; }
        public int ComplainantId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
