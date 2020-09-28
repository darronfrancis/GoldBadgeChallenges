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
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
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
            Customer content = GetCustomerByName(firstName, lastName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfCustomers.Count;
            _listOfCustomers.Remove(content);

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
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
