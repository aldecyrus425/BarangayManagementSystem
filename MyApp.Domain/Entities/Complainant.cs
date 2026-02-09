using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Complainant
    {
        public int ComplainantId { get; set; }
        public string ComplainantFirstName { get; set; }
        public string ComplainantLastName { get; set; }
        public int ComplainantAge { get; set; }
        public string ComplainantAddress { get; set; }
        public string ComplainantContact {  get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        protected Complainant() { }

        public Complainant(string complainantFirstName, string complainantLastName, int complainantAge, string complainantAddress, string complainantContact)
        {
            if (string.IsNullOrWhiteSpace(complainantFirstName))
                throw new ArgumentException("Complainant first name is required.");

            if (string.IsNullOrWhiteSpace(complainantLastName))
                throw new ArgumentException("Complainant last name is required.");

            if (complainantAge <= 0)
                throw new ArgumentException("Complainant age is invalid.");

            if (string.IsNullOrWhiteSpace(complainantAddress))
                throw new ArgumentException("Complainant address is required.");

            if (string.IsNullOrWhiteSpace(complainantContact))
                throw new ArgumentException("Complainant contact is required.");

            ComplainantFirstName = complainantFirstName;
            ComplainantLastName = complainantLastName;
            ComplainantAge = complainantAge;
            ComplainantAddress = complainantAddress;
            ComplainantContact = complainantContact;
        }

        public void UpdateComplainant(string complainantFirstName, string complainantLastName, int complainantAge, string complainantAddress, string complainantContact)
        {
            if (string.IsNullOrWhiteSpace(complainantFirstName))
                throw new ArgumentException("Complainant first name is required.");

            if (string.IsNullOrWhiteSpace(complainantLastName))
                throw new ArgumentException("Complainant last name is required.");

            if (complainantAge <= 0)
                throw new ArgumentException("Complainant age is invalid.");

            if (string.IsNullOrWhiteSpace(complainantAddress))
                throw new ArgumentException("Complainant address is required.");

            if (string.IsNullOrWhiteSpace(complainantContact))
                throw new ArgumentException("Complainant contact is required.");

            ComplainantFirstName = complainantFirstName;
            ComplainantLastName = complainantLastName;
            ComplainantAge = complainantAge;
            ComplainantAddress = complainantAddress;
            ComplainantContact = complainantContact;
        }

    }
}
