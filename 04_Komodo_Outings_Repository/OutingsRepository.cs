using _04_Komodo_Outings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings_Repository
{
    public class OutingRepository
    {
        private List<OutingsContent> _outingsContent = new List<OutingsContent>();

        public List<OutingsContent> GetList()
        {
            return _outingsContent;
        }

        public double CostByType(OutingType outingType)
        {
            List<OutingsContent> outingsContent = GetOutingByType(outingType);
            double totalCost = 0.0d;
            foreach (OutingsContent outing in outingsContent)
            {
                totalCost += outing.TotalEventCost;
            }
            return totalCost;
        }

        public double TotalCost()
        {
            double totalCost = 0.0d;
            foreach (OutingsContent item in _outingsContent)
            {
                totalCost += item.TotalEventCost;
            }
            return totalCost;
        }

        private List<OutingsContent> GetOutingByType(OutingType outingType)
        {
            List<OutingsContent> outingsContent = new List<OutingsContent>();
            foreach (OutingsContent item in _outingsContent)
            {
                if (item.OutingType == outingType)
                {
                    outingsContent.Add(item);
                }
            }
            return (outingsContent);

        }

        public void AddNewOuting(OutingsContent outing)
        {
            _outingsContent.Add(outing);
        }
    }
}
