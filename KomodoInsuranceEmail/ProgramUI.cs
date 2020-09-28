using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceEmail
{
    class ProgramUI
    {
        private EmailRepository _customerList = new EmailRepository();

        public void Run()
        {
            SeedList();
            Menu();
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. See Customers\n" +
                    "2. Add Customer\n" +
                    "3. Update Customer\n" +
                    "4. Delete Customer\n" +
                    "5. Email Customer\n" +
                    "6. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DeleteCustomer();
                        break;
                    case 5:
                        EmailCustomer();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ListCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _customerList.GetCustomers();
            foreach (Customer item in listOfCustomers)
            {
                string customerStatus = item.Type.ToString();
                if (customerStatus == "potential")
                {
                    customerStatus = "Potential Customer";
                }
                else if (customerStatus == "current")
                {
                    customerStatus = "Current Customer";
                }
                else if (customerStatus == "past")
                {
                    customerStatus = "Past Customer";
                }
                Console.WriteLine($"{item.FirstName} {item.LastName} - {customerStatus}");
            }

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void AddCustomer()
        {
            Customer newCustomer = new Customer();
            Console.Clear();
            Console.WriteLine("First Name:");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Customer Type (potential, current, past):");
            string input = Console.ReadLine().ToLower();
            if (input == "potential")
            {
                newCustomer.Type = Customer.CustomerType.potential;
            }
            else if (input == "current")
            {
                newCustomer.Type = Customer.CustomerType.current;
            }
            else if (input == "past")
            {
                newCustomer.Type = Customer.CustomerType.past;
            }
            else
            {
                Console.WriteLine("Input not recognized");
            }
            _customerList.AddNewCustomer(newCustomer);

            Console.Clear();
            Console.WriteLine($"\nYou've added a new customer.\n" +
                $"First Name: {newCustomer.FirstName}\n" +
                $"Last Name: {newCustomer.LastName}\n" +
                $"Customer Status: {newCustomer.Type}\n\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.Clear();

            List<Customer> listOfCustomers = _customerList.GetCustomers();
            foreach (Customer item in listOfCustomers)
            {
                string customerStatus = item.Type.ToString();
                if (customerStatus == "potential")
                {
                    customerStatus = "Potential Customer";
                }
                else if (customerStatus == "current")
                {
                    customerStatus = "Current Customer";
                }
                else if (customerStatus == "past")
                {
                    customerStatus = "Past Customer";
                }
                Console.WriteLine($"{item.FirstName} {item.LastName} - {customerStatus}");
            }

            Console.WriteLine("\nWhich customer would you like to update?\n" +
                "First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Customer content = _customerList.GetCustomerByName(firstName, lastName);

            Console.Clear();
            Console.WriteLine($"You are editing info for {content.FirstName} {content.LastName}.  Please enter the updated info:\n" +
                "First Name:");
            content.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            content.LastName = Console.ReadLine();
            Console.WriteLine("Customer Status (potential, current, past):");
            string response = Console.ReadLine();
            if (response.ToLower() == "potential")
            {
                content.Type = Customer.CustomerType.potential;
            }
            else if (response.ToLower() == "current")
            {
                content.Type = Customer.CustomerType.current;
            }
            else if (response.ToLower() == "past")
            {
                content.Type = Customer.CustomerType.past;
            }

            Console.WriteLine("\nYour customer has been updated.");

            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
        } 

        private void DeleteCustomer()
        {
            Console.Clear();

            List<Customer> listOfCustomers = _customerList.GetCustomers();
            foreach (Customer item in listOfCustomers)
            {
                string customerStatus = item.Type.ToString();
                if (customerStatus == "potential")
                {
                    customerStatus = "Potential Customer";
                }
                else if (customerStatus == "current")
                {
                    customerStatus = "Current Customer";
                }
                else if (customerStatus == "past")
                {
                    customerStatus = "Past Customer";
                }
                Console.WriteLine($"{item.FirstName} {item.LastName} - {customerStatus}");
            }

            Console.WriteLine("\nWhich customer would you like to delete?\n" +
                "First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            _customerList.DeleteCustomer(firstName, lastName);

            Console.Clear();
            Console.WriteLine("Your customer has been deleted.  Current Customers:");
            foreach (Customer item in listOfCustomers)
            {
                string customerStatus = item.Type.ToString();
                if (customerStatus == "potential")
                {
                    customerStatus = "Potential Customer";
                }
                else if (customerStatus == "current")
                {
                    customerStatus = "Current Customer";
                }
                else if (customerStatus == "past")
                {
                    customerStatus = "Past Customer";
                }
                Console.WriteLine($"{item.FirstName} {item.LastName} - {customerStatus}");
            }


            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void EmailCustomer()
        {
            Console.Clear();

            List<Customer> listOfCustomers = _customerList.GetCustomers();
            foreach (Customer item in listOfCustomers)
            {
                string customerStatus = item.Type.ToString();
                if (customerStatus == "potential")
                {
                    customerStatus = "Potential Customer";
                }
                else if (customerStatus == "current")
                {
                    customerStatus = "Current Customer";
                }
                else if (customerStatus == "past")
                {
                    customerStatus = "Past Customer";
                }
                Console.WriteLine($"{item.FirstName} {item.LastName} - {customerStatus}");
            }

            Console.WriteLine("\nWhich customer would you like to email?\n" +
                "First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Customer content = _customerList.GetCustomerByName(firstName, lastName);

            Console.Clear();
            if (content.Type == Customer.CustomerType.potential)
            {
                Console.WriteLine($"Here is your email to {content.FirstName} {content.LastName}:\n\n" +
                    $"Greetings, {content.FirstName},\n" +
                    $"We currently have the lowest rates on Helicopter Insurance!  Give us a call today!\n" +
                    $"Komodo Insurance\n\n" +
                    $"Are you ready to send email?  Press any key to continue...");
                Console.ReadKey();
            }
            else if (content.Type == Customer.CustomerType.current)
            {
                Console.WriteLine($"Here is your email to {content.FirstName} {content.LastName}:\n\n" +
                    $"Greetings, {content.FirstName},\n" +
                    $"Thank you for your work with us. We appreciate your loyalty. Here's a coupon.\n" +
                    $"Komodo Insurance\n\n" +
                    $"Are you ready to send email?  Press any key to continue...");
                Console.ReadKey();
            }
            else if (content.Type == Customer.CustomerType.past)
            {
                Console.WriteLine($"Here is your email to {content.FirstName} {content.LastName}:\n\n" +
                    $"Greetings, {content.FirstName},\n" +
                    $"It's been a long time since we've heard from you, we want you back.\n" +
                    $"Komodo Insurance\n\n" +
                    $"Are you ready to send email?  Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void SeedList()
        {
            Customer customer1 = new Customer("John", "Smith", Customer.CustomerType.current);
            Customer customer2 = new Customer("Edna", "Smith", Customer.CustomerType.current);
            Customer customer3 = new Customer("Billy", "Smith", Customer.CustomerType.potential);
            Customer customer4 = new Customer("Louise", "Smith", Customer.CustomerType.past);
            _customerList.AddNewCustomer(customer1);
            _customerList.AddNewCustomer(customer2);
            _customerList.AddNewCustomer(customer3);
            _customerList.AddNewCustomer(customer4);
        }
    }
}
