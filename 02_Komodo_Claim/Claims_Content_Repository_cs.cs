using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claim
{
    public class ClaimsContentRepositorycs : ClaimsContentRepository
    {
        public ClaimsContent GetClaimById(int claimId)
        {
            foreach (ClaimsContent content in _contentDirectory)
            {
                if (content.ClaimId == claimId && content.GetType() == typeof(ClaimsContent))
                {
                    return content;
                }

            }
            return null;
        }

        public List<ClaimsContent> GetAllClaims()
        {
            List<ClaimsContent> allClaims = new List<ClaimsContent>();

            foreach (ClaimsContent content in _contentDirectory)
            {
                if (content is ClaimsContent)
                {
                    allClaims.Add((ClaimsContent)content);
                }
            }
            return allClaims;
        }
    }
}

