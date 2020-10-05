using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }

    public class OutingsContent
    {
        public OutingType OutingType { get; set; }
        public int Count { get; set; }
        public DateTime EventDate { get; set; }
        public double CostEachPerson { get; set; }
        public double TotalEventCost { get; set; }

        public OutingsContent() { }
        public OutingsContent(OutingType outingType, int count, DateTime eventDate, double costEachPerson, double totalEventCost)
        {

        OutingType = outingType;
        Count = count;
        EventDate = eventDate;
        CostEachPerson = costEachPerson;
        TotalEventCost = totalEventCost;
        }
    }
}

