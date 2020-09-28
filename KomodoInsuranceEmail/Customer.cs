using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceEmail
{
    public class Customer
    {
        public enum CustomerType { potential, current, past };

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }

        public Customer() { }

        public Customer(string firstName, string lastName, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
    }
}
