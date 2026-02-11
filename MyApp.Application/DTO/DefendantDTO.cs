using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class DefendantDTO
    {
        public int DefendantId { get; set; }
        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public int DefendantAge { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantContact { get; set; }

        public GetResidentDTO Resident { get; set; }
        public int UserId { get; set; }
    }

    public class AddDefendantDTO
    {
        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public int DefendantAge { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantContact { get; set; }
        public int UserID { get; set; }
    }

    public class updateDefendantDTO
    {
        public int DefendantId { get; set; }

        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public int DefendantAge { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantContact { get; set; }
    }
}
