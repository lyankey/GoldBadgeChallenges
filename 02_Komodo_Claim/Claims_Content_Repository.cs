using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claim
{
    public class ClaimsContentRepository
    {
        protected readonly List<ClaimsContent> _contentDirectory = new List<ClaimsContent>();
        public bool AddContentToDirectory(ClaimsContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<ClaimsContent> GetContents()
        {
            return _contentDirectory;
        }

        public ClaimsContent GetNextClaim(int claimId)
        {
            if (claimId >= GetContents().Count - 1)
            {
                ClaimsContentRepositorycs claimsContentRepositorycs = new ClaimsContentRepositorycs();
                ClaimsContent nextClaim = claimsContentRepositorycs.GetClaimById(claimId);
                return nextClaim;
            }

            return null;
        }


        //They did not want update or delete
    }
}

