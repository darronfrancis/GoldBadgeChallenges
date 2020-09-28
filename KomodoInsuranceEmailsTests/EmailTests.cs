using System;
using KomodoInsuranceEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoInsuranceEmailsTests
{
    [TestClass]
    public class EmailTests
    {
        EmailRepository item = new EmailRepository();

        [TestMethod]
        public void AddCustomer()
        {
            Customer newCustomer = new Customer("Darron", "Francis", Customer.CustomerType.current);

            item.AddNewCustomer(newCustomer);
        }

        [TestMethod]
        public void GetCustomers()
        {
            item.GetCustomers();
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            Customer newCustomer = new Customer("Darron", "Sicnarf", Customer.CustomerType.past);
            
            item.UpdateCustomer("Darron", "Francis", newCustomer);
        }

        [TestMethod]
        public void DeleteCustomer()
        {
            item.DeleteCustomer("Darron", "Francis");
        }
    }
}
