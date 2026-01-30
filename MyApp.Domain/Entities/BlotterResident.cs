using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class BlotterResident
    {
        [Key]
        public int BlotterId { get; set; }

        public Resident Resident { get; set; }
        public int ResidentId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
