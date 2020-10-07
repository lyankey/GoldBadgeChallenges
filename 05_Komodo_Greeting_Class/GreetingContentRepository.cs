using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Komodo_Greeting_Class
{
    public class GreetingContentRepository
    {
        //make the lsit
        public List<GreetingContent> _custRepo = new List<GreetingContent>();

        //CRUD
      
        public bool AddNewCust(GreetingContent newCust )
        {
            int startingCount = _custRepo.Count();
            _custRepo.Add(newCust);
            bool wasAdded = _custRepo.Count() == startingCount++;
            return wasAdded;
        }

        //read

        //get all
        public List<GreetingContent> GetAllCustomers()
        {
            return _custRepo;
        }

        //get one 

        public GreetingContent oneCust(string lastName, string firstName)
        {
                foreach (GreetingContent oneCust in _custRepo)
            {
                if(oneCust.LastName == lastName && oneCust.FirstName == firstName)
                {
                    return oneCust;
                }
            }
                return null;

        }
        //update

        //update customer - type, firstname, lastname
        //delete customer

        //delete
        //removecustomer



    }
} 