using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTO
{
    public class ComplainantDTO
    {
        public int ComplainantId { get; set; }
        public string ComplainantFirstName { get; set; }
        public string ComplainantLastName { get; set; }
        public int ComplainantAge { get; set; }
        public string ComplainantAddress { get; set; }
        public string ComplainantContact { get; set; }

        public int UserId { get; set; }
    }

    public class AddComplainantDTO
    {
        public string ComplainantFirstName { get; set; }
        public string ComplainantLastName { get; set; }
        public int ComplainantAge { get; set; }
        public string ComplainantAddress { get; set; }
        public string ComplainantContact { get; set; }
    }

    public class UpdateComplainantDTO
    {
        public string ComplainantFirstName { get; set; }
        public string ComplainantLastName { get; set; }
        public int ComplainantAge { get; set; }
        public string ComplainantAddress { get; set; }
        public string ComplainantContact { get; set; }
    }
}
