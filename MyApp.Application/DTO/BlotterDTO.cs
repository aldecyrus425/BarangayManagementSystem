using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class BlotterDTO
    {
        public int BlotterId { get; set; }
        public DateTime BlotterDate { get; set; }
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }
    }

    public class AddBlotterDTO
    {
        public DateTime BlotterDate { get; set; }
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }

        public int ComplainantId { get; set; }

        public int UserId { get; set; }
    }

    public class UpdateBlotterDTO
    {
        public int BlotterId { get; set; }
        public DateTime BlotterDate { get; set; }
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }
        public int ComplainantId { get; set; }
    }
}
