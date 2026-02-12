using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class BlotterResidentDTO
    {
        public int BlotterId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }

    public class AddBlotterResidentDTO
    {
        public int UserId { get; set; }
        public int ResidentId { get; set; }
    }

    public class UpdateBlotterResidentDTO
    {
        public int BlotterId { get; set; }
        public int UserId { get; set; }
        public int ResidentId { get; set; }
    }
}
