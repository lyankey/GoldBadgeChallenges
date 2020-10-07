using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Komodo_Greeting_Class
{
    public enum CustType { Current, Past, Future}
    public class GreetingContent
    {
        public CustType CustType { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Email
        {
            get
            {
                if (CustType == CustType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (CustType == CustType.Past)
                {
                    return "It's been a long time since we've heard from you, we want you back".;
                }
                else if (CustType == CustType.Future)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
