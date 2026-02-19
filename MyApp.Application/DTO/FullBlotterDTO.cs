using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class FullBlotterDTO
    {
        public DateTime BlotterDate { get; set; }
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }
        public int UserId { get; set; }

        public AddComplainantDTO Complainant { get; set; }
        public AddDefendantDTO Defendant { get; set; }

    }
}
