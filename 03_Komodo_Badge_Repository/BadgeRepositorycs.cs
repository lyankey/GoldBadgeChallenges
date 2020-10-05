using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge_Repository
{
    public class BadgeRepositorycs : BadgeRepository
    {
        public List<string> GetBadgeById(int badgeId)
        {
            foreach (KeyValuePair<int, List<string>> content in _badgesDirectory)
            {
                if (content.Key == badgeId)
                {
                    return content.Value;
                }
            }
            return null;
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgesDirectory;
        }
    }
}
