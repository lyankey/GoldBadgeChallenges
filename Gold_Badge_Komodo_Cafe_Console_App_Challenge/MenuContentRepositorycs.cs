using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Komodo_Cafe_Console_App_Challenge_Repository
{
    public class MenuRepositorycs : MenuContentRepository
    {
        public MenuContent GetMenuItemByName(string name)
        {
            foreach (MenuContent content in _contentDirectory)
            {
                if (content.Name.ToLower() == name.ToLower() && content.GetType() == typeof(MenuContent))
                {
                    return (MenuContent)content;
                }
            }
            return null;
        }

        public List<MenuContent> GetAllMenuItems()
        {
            List<MenuContent> allMenuItems = new List<MenuContent>();
 
            foreach (MenuContent content in _contentDirectory)
            {
                if (content is MenuContent)
                {
                    allMenuItems.Add((MenuContent)content);
                }
            }
            return allMenuItems;
        }
    }
}
