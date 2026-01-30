using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class BlotterDefendant
    {
        public int BlotterDefendantId { get; set; }

        public Blotter Blotter { get; set; }
        public int BlotterId { get; set; }

        public Defendant Defendant { get; set; }
        public int DefendantId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
