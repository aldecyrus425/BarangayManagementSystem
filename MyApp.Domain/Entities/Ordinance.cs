using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Ordinance
    {
        public int OrdinanceId { get; set; }
        public string OrdinanceNumber { get; set; }
        public string IntroducedBy { get; set; }
        public string Description { get; set; }
        public DateTime DateEnacted { get; set; }
        public string Approved_By { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        protected Ordinance() { }

        public Ordinance(string ordinanceNumber, string introducedBy, string description, DateTime dateEnacted, string approvedBy, int userId)
        {
            if (string.IsNullOrWhiteSpace(ordinanceNumber))
                throw new ArgumentNullException("Ordinance number is required.");

            if (string.IsNullOrWhiteSpace(introducedBy))
                throw new ArgumentNullException("Introduced by is required.");

            if(string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("Description is required");

            if (dateEnacted > DateTime.Today)
                throw new ArgumentException("Date Enacted cannot be in future.");

            if (string.IsNullOrWhiteSpace(approvedBy))
                throw new ArgumentNullException("Approve by is required.");

            if (userId <= 0)
                throw new ArgumentException("Invalid user id.");

            OrdinanceNumber = ordinanceNumber;
            IntroducedBy = introducedBy;
            Description = description;
            DateEnacted = dateEnacted;
            Approved_By = approvedBy;
            UserId = userId;
        }

        public void UpdateOrdinance(string ordinanceNumber, string introducedBy, string description, DateTime dateEnacted, string approvedBy, int userId)
        {
            if (string.IsNullOrWhiteSpace(ordinanceNumber))
                throw new ArgumentNullException("Ordinance number is required.");

            if (string.IsNullOrWhiteSpace(introducedBy))
                throw new ArgumentNullException("Introduced by is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("Description is required");

            if (dateEnacted > DateTime.Today)
                throw new ArgumentException("Date Enacted cannot be in future.");

            if (string.IsNullOrWhiteSpace(approvedBy))
                throw new ArgumentNullException("Approve by is required.");

            if (userId <= 0)
                throw new ArgumentException("Invalid user id.");

            OrdinanceNumber = ordinanceNumber;
            IntroducedBy = introducedBy;
            Description = description;
            DateEnacted = dateEnacted;
            Approved_By = approvedBy;
            UserId = userId;
        }
    }

}
