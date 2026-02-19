using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class BlotterDefendantDTO
    {
        public int BlotterDefendantId { get; set; }

        public Blotter Blotter { get; set; }
        public int BlotterId { get; set; }

        public Defendant Defendant { get; set; }
        public int DefendantId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }

    public class AddBlotterDefendantDTO
    {
        public int BlotterId { get; set; }
        public int DefendantId { get; set; }
        public int UserId { get; set; }
    }

   
}
