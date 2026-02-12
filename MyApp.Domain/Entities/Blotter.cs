using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Blotter
    {
        public int BlotterId { get; set; }
        public DateTime BlotterDate { get; set; }
        public string BlotterComplaint { get; set; }
        public string BlotterActionTaken { get; set; }
        public string BlotterStatus { get; set; }
        public string LocationOfIncidence { get; set; }
        public DateTime SettlementDate { get; set; }
        
        public Complainant Complainant { get; set; }
        public int ComplainantId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        protected Blotter() { }

        public Blotter(DateTime blotterDate, string blotterComplaint, string blotterActionTaken, string blotterstatus, string localOfIncidence, DateTime settlementDate, int complainantId, int userId)
        {
            if (blotterDate > DateTime.Today)
                throw new ArgumentException("Blotter date cannot be in future.");

            if (string.IsNullOrWhiteSpace(blotterComplaint))
                throw new ArgumentException("Blotter complaint is required.");

            if (string.IsNullOrWhiteSpace(blotterActionTaken))
                throw new ArgumentException("Blotter action taken is required.");
            if (string.IsNullOrWhiteSpace(localOfIncidence))
                throw new ArgumentException("Blotter of incidence is required.");
            if (settlementDate > DateTime.Today)
                throw new ArgumentException("Settlement date cannot be in future.");
            if (complainantId <= 0)
                throw new ArgumentException("Invalid complainant ID.");
            if (userId <= 0)
                throw new ArgumentException("Invalid User ID");

            BlotterDate = blotterDate;
            BlotterComplaint = blotterComplaint;
            BlotterActionTaken = blotterActionTaken;
            BlotterStatus = blotterstatus;
            LocationOfIncidence = localOfIncidence;
            SettlementDate = settlementDate;
            ComplainantId = complainantId;
            UserId = userId;

        }

        public void UpdateBlotter(DateTime blotterDate, string blotterComplaint, string blotterActionTaken, string blotterstatus, string localOfIncidence, DateTime settlementDate, int complainantId)
        {
            if (blotterDate > DateTime.Today)
                throw new ArgumentException("Blotter date cannot be in future.");

            if (string.IsNullOrWhiteSpace(blotterComplaint))
                throw new ArgumentException("Blotter complaint is required.");

            if (string.IsNullOrWhiteSpace(blotterActionTaken))
                throw new ArgumentException("Blotter action taken is required.");
            if (string.IsNullOrWhiteSpace(localOfIncidence))
                throw new ArgumentException("Blotter of incidence is required.");
            if (settlementDate > DateTime.Today)
                throw new ArgumentException("Settlement date cannot be in future.");
            if (complainantId <= 0)
                throw new ArgumentException("Invalid complainant ID.");

            BlotterDate = blotterDate;
            BlotterComplaint = blotterComplaint;
            BlotterActionTaken = blotterActionTaken;
            BlotterStatus = blotterstatus;
            LocationOfIncidence = localOfIncidence;
            SettlementDate = settlementDate;
            ComplainantId = complainantId;

        }
    }
}
