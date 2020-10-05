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
        protected readonly Dictionary<int, BadgeContent> _contentDirectory = new Dictionary<int, BadgeContent>();
        //CRUD Create Read Update Delete

        public bool AddContentToDirectory(BadgeContent content)
        {
            int startingCount = _contentDirectory.Count();
            //_contentDirectory.Add(content);
            //bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return true;
        }
        //READ ALL
        public Dictionary<int, BadgeContent> GetContents()
        {
            return _contentDirectory;
        }
        //READ ONE
        public BadgeContent GetContentById(int badgeId)
        {
            BadgeContent badgeContent = new BadgeContent();
            bool hasValue = _contentDirectory.TryGetValue(badgeId, out badgeContent);
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
        public bool UpdateExistingContent(int badgeId, BadgeContent newContent)
        {
            BadgeContent oldContent = GetContentById(badgeId);
            if (oldContent != null)
            {
                oldContent.BadgeId = newContent.BadgeId;
                oldContent.Doors = newContent.Doors;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingContent(BadgeContent existingContent)
        {
            // bool deleteResult = _contentDirectory.Remove(existingContent);
            return false;
        }
    }
   
}
