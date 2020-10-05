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

        public bool AddContentToDirectory(BadgeContent content)
        {
            int startingCount = _badgesDirectory.Count();
            _badgesDirectory.Add(content.BadgeId, content.Doors);
            bool wasAdded = (_badgesDirectory.Count > startingCount) ? true : false;
            return true;
        }
        //READ ALL
        public Dictionary<int, List<string>> GetContents()
        {
            return _badgesDirectory;
        }
        //READ ONE
        public List<string> GetContentById(int badgeId)
        {
            List<string> myValue = new List<string>();
            bool hasValue = _badgesDirectory.TryGetValue(badgeId, out myValue);
            if (hasValue)
            {
                // key exists
                return _badgesDirectory[badgeId];
            }
            else
            {
                // key doesn't exist
                return null;
            }
            //return null;

        }
        //Update 
        public bool UpdateExistingContent(int badgeId, BadgeContent newContent)
        {
   
            return false;
        }
        //Delete
        public bool DeleteExistingContent(BadgeContent existingContent)
        {
            // bool deleteResult = _contentDirectory.Remove(existingContent);
            return false;
        }
    }

}