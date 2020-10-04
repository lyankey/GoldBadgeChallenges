using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claim
{
    public class ValidityCheck
    {
        public bool IsTimeDifferenceOverCertainDays(DateTime dateAccident, DateTime dateClaim, int numberofDays)
        {
            TimeSpan interval = dateClaim.Subtract(dateAccident);

            if (interval.Days <= numberofDays)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

