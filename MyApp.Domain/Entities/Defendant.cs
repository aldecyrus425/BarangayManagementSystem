using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Defendant
    {
        public int DefendantId { get; set; }
        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public int DefendantAge { get; set; }
        public string DefendantAddress { get; set; }
        public string DefendantContact { get; set; }

        public User User {  get; set; }
        public int UserId { get; set; }

        public Resident Resident { get; set; }
        public int ResidentID { get; set; }

        protected Defendant() { }

        public Defendant(string defendantFirstname, string defendantLastname, int defendantAge, string defendantAddress, string defendantContact, int userID)
        {
            if (string.IsNullOrWhiteSpace(defendantFirstname))
                throw new ArgumentException("Defendant first name is required.");

            if (string.IsNullOrWhiteSpace(defendantLastname))
                throw new ArgumentException("Defendant last name is required.");

            if (defendantAge <= 0)
                throw new ArgumentException("Defendant age cannot be in future.");

            if (string.IsNullOrWhiteSpace(defendantAddress))
                throw new ArgumentException("Defendant address is required.");

            if (string.IsNullOrWhiteSpace(defendantContact))
                throw new ArgumentException("Defendant contact is required.");

            if (userID <= 0)
                throw new ArgumentException("User ID is invalid.");

            DefendantFirstName = defendantFirstname;
            DefendantLastName = defendantLastname;
            DefendantAge = defendantAge;
            DefendantAddress = defendantAddress;
            DefendantContact = defendantContact;
            UserId = userID;
        }

        public void UpdateDefendant(string defendantFirstname, string defendantLastname, int defendantAge, string defendantAddress, string defendantContact)
        {
            if (string.IsNullOrWhiteSpace(defendantFirstname))
                throw new ArgumentException("Defendant first name is required.");

            if (string.IsNullOrWhiteSpace(defendantLastname))
                throw new ArgumentException("Defendant last name is required.");

            if (defendantAge <= 0)
                throw new ArgumentException("Defendant age cannot be in future.");

            if (string.IsNullOrWhiteSpace(defendantAddress))
                throw new ArgumentException("Defendant address is required.");

            if (string.IsNullOrWhiteSpace(defendantContact))
                throw new ArgumentException("Defendant contact is required.");

            DefendantFirstName = defendantFirstname;
            DefendantLastName = defendantLastname;
            DefendantAge = defendantAge;
            DefendantAddress = defendantAddress;
            DefendantContact = defendantContact;
        }
    }
}
