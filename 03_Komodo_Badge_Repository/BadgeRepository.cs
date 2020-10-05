using _03_Komodo_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge_Repository
{
    public class BadgeRepository
    {
        public Dictionary<int, List<string>> _badgesDirectory = new Dictionary<int, List<string>>();
        //CRUD Create Read Update Delete

        public bool ContainsKey(int key)
        {
            bool keyIs = _badgesDirectory.ContainsKey(key);
            if (keyIs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddContentToDirectory(int badgeId)
        {
            List<string> doors = new List<string>();
            BadgeContent newBadge = new BadgeContent(badgeId, doors);
            if (!ContainsKey(badgeId))
            {
                _badgesDirectory.Add(newBadge.BadgeId, newBadge.Doors);
            }
       
         
        }
        //READ ALL
        public Dictionary<int, List<string>> GetContents()
        {
            return _badgesDirectory;
        }
        //READ ONE
        public List<string> GetContentById(int badgeId)
        {
            List<string> badgeContent = new List<string>();
            bool hasValue = _badgesDirectory.TryGetValue(badgeId, out badgeContent);
            if (hasValue)
            {
                // key exists
                return badgeContent;
            }
            else
            {
                // key doesn't exist
                return null;
            }

        }
        //Update 
        public void AddNewBadge(int badgeId)
        {
            List<string> doors = new List<string>();
            BadgeContent newBadge = new BadgeContent(badgeId, doors);
            if (!ContainsKey(badgeId))
            {
                _badgesDirectory.Add(newBadge.BadgeId, newBadge.Doors);
            }
            else
            {
                Console.WriteLine("This badge ID has already been used.");
            }
        }
        //Delete
        public bool DeleteExistingDoors(int badgeId)
        {
            _badgesDirectory[badgeId].Clear();
            return false;
        }
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _badgesDirectory;
        }
    }
   
}
