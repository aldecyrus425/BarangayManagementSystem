using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
