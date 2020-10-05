using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge
{
    public class BadgeContent
    {
        public int BadgeId { get; set; }
        public List<string> Doors { get; set; } = new List<string>();

        public BadgeContent() { }
        public BadgeContent(int badgeId, List<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }
    }
}
