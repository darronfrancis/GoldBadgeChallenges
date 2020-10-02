using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceEmail
{
    public class EmailRepository
    {
        List<Customer> _listOfCustomers = new List<Customer>();

        //ADD
        public void AddNewCustomer(Customer item)
        {
            _listOfCustomers.Add(item);
        }

        //READ
        public List<Customer> GetCustomers()
        {
            return _listOfCustomers;
        }
        
        //UPDATE
        public bool UpdateCustomer(string firstName, string lastName, Customer newContent)
        {
            Customer oldContent = GetCustomerByName(firstName, lastName);

            if(oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName.ToLower();
                oldContent.LastName = newContent.LastName.ToLower();
                oldContent.Type = newContent.Type;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool DeleteCustomer(string firstName, string lastName)
        {
            Customer content = GetCustomerByName(firstName.ToLower(), lastName.ToLower());
            int initialCount = _listOfCustomers.Count;

            if (content.FirstName.ToLower() == firstName.ToLower() && content.LastName.ToLower() == lastName.ToLower())
            {
                _listOfCustomers.Remove(content);
            }
            else
            {
                return false;
            }
            if(initialCount > _listOfCustomers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            foreach (Customer item in _listOfCustomers)
            {
                if (item.FirstName.ToLower() == firstName.ToLower() && item.LastName.ToLower() == lastName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
