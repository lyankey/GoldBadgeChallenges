using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claim
{
    public enum ClaimType
    {
        Car = 1,
        Home = 2,
        Theft = 3
    }

    public class ClaimsContent
    {
        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateClaim { get; set; }
        public DateTime DateAccident { get; set; }
        public bool? IsValid { get; set; }

        public ClaimsContent() { }
        public ClaimsContent(int claimId, ClaimType cType, string description, decimal amount, DateTime dateClaim, DateTime dateAccident, bool isValid)
        {
            ClaimId = claimId;
            Description = description;
            Amount = amount;
            DateClaim = dateClaim;
            DateAccident = dateAccident;
            ClaimType = cType;
            IsValid = isValid;
        }
    }
}
