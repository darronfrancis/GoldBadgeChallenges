using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class Claim
    {
        public enum Type { Car, Home, Theft }

        public int ClaimID { get; set; }
        public Type ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimID, Type claimType, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
