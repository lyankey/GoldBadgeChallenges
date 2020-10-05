using _03_Komodo_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge_Repository
{
    class BadgeRepositorycs : BadgeRepository
    {
        public BadgeContent GetBadgeById(int badgeId)
        {
            foreach (var content in _contentDirectory)
            {
                if (content.Key == badgeId && content.GetType() == typeof(BadgeContent))
                {
                    return content.Value;
                }
            }
            return null;
        }

        public Dictionary<int, BadgeContent> GetAllBadges()
        {
            return _contentDirectory;
        }

        // private static Dictionary<int, object> dict;
        //private static void Add(int badgeId, object dataType)
        //{
        //    if (!dict.ContainsKey(badgeId))
        //    {
        //        dict.Add(badgeId, dataType);
        //    }
        //    else
        //    {
        //        dict[badgeId] = dataType;
        //    }
        //}

        //private static T GetAnyValue<T>(int badgeId)
        //{
        //    object obj;
        //    T retType;

        //    dict.TryGetValue(badgeId, out obj);

        //    try
        //    {
        //        retType = (T)obj;
        //    }
        //    catch
        //    {
        //        retType = default(T);
        //    }
        //    return retType;
        //}
    }
}
