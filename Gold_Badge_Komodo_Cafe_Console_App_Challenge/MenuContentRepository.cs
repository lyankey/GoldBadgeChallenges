using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository
{
    public class MenuContentRepository
    {
        protected readonly List<MenuContent> _contentDirectory = new List<MenuContent>();
        //CRUD Create Read Update Delete

        public bool AddContentToDirectory(MenuContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //READ ALL
        public List<MenuContent> GetContents()
        {
            return _contentDirectory;
        }
        //READ ONE
        public MenuContent GetContentByName(string name)
        {
            foreach (MenuContent singleContent in _contentDirectory)
            {
                if (singleContent.Name.ToLower() == name.ToLower())
                {
                    return singleContent;
                }
            }
            return null;
        }
        //Update 
        public bool UpdateExistingContent(string originalName, MenuContent newContent)
        {
            MenuContent oldContent = GetContentByName(originalName);
            if (oldContent != null)
            {
                oldContent.Id = newContent.Id;
                oldContent.Name = newContent.Name;
                oldContent.Description = newContent.Description;
                oldContent.Price = newContent.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingContent(MenuContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
