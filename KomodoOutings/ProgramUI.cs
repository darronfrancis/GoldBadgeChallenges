using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    class ProgramUI
    {
        private OutingRepository _outingList = new OutingRepository();

        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Display a List of Outings\n" +
                    "2. Add an Outing\n" +
                    "3. Total Cost of Outings\n" +
                    "4. Total Cost of Outings by Type\n" +
                    "5. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        GetOutings();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        TotalCostOfOutings();
                        break;
                    case 4:
                        CostOfOutingByType();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("Event Type (amusement park, bowling, concert, golf:");
            string response = Console.ReadLine();
            if (response.ToLower() == "amusement park")
            {
                newOuting.EventType = Outing.Type.amusementPark;
            }
            else if (response.ToLower() == "bowling")
            {
                newOuting.EventType = Outing.Type.bowling;
            }
            else if (response.ToLower() == "concert")
            {
                newOuting.EventType = Outing.Type.concert;
            }
            else if (response.ToLower() == "golf")
            {
                newOuting.EventType = Outing.Type.golf;
            }
            Console.WriteLine("Date of Event:");
            newOuting.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Total Attendance:");
            newOuting.Attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("Cost per Person:");
            newOuting.Ticket = decimal.Parse(Console.ReadLine());

            _outingList.AddOuting(newOuting);

            Console.WriteLine($"Outing created.\n" +
                $"Event Type: {newOuting.EventType}\n" +
                $"Date of Event: {newOuting.Date.ToString("MM/dd/yy")}\n" +
                $"Total Attendance: {newOuting.Attendance}\n" +
                $"Cost per Person: ${newOuting.Ticket}\n" +
                $"Press any key to continue.");
            Console.ReadKey();
        }

        private void GetOutings()
        {
            Console.Clear();
            List<Outing> menuItem = _outingList.GetOuting();
            Console.WriteLine("Event Type * Date * Total Attendance * Cost per Person");
            foreach (Outing item in menuItem)
            {
                string type = null;
                if (item.EventType == Outing.Type.amusementPark) { type = "Amusement Park"; }
                else if (item.EventType == Outing.Type.bowling) { type = "Bowling"; }
                else if (item.EventType == Outing.Type.concert) { type = "Concert"; }
                else if (item.EventType == Outing.Type.golf) { type = "Golf"; }
                Console.WriteLine($"{type} * {item.Date.ToString("MM/dd/yy")} * {item.Attendance} * ${item.Ticket}");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }

        private void TotalCostOfOutings()
        {
            Console.Clear();
            List<Outing> content = _outingList.GetOuting();
            decimal totalCost = 0;
            foreach (var item in content)
            {
                totalCost += (item.Ticket * item.Attendance);
            }
            Console.WriteLine($"The total cost of outings thus far is ${String.Format("{0:n}", totalCost)}.\n\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void CostOfOutingByType()
        {
            Console.Clear();
            List<Outing> outing = _outingList.GetOuting();
            decimal totalCost = 0;
            Console.WriteLine("For which type of event would you like to analyze the total cost?\n" +
                "(Amusement Park, Bowling, Concert, or Golf)");
            string response = String.Concat(Console.ReadLine().Where(c => !Char.IsWhiteSpace(c)));

            foreach (var item in outing)
            {
                if (response.ToLower() == item.EventType.ToString().ToLower())
                {
                    totalCost += (item.Ticket * item.Attendance);
                }
            }
            Console.WriteLine($"The total cost of {response} outings thus far is ${String.Format("{0:n}", totalCost)}.\n\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void Seed()
        {
            Outing outing1 = new Outing(Outing.Type.amusementPark, DateTime.Parse("03/20/2020"), 35, 45);
            Outing outing2 = new Outing(Outing.Type.amusementPark, DateTime.Parse("05/15/2020"), 72, 60);
            Outing outing3 = new Outing(Outing.Type.amusementPark, DateTime.Parse("08/02/2020"), 125, 85);
            Outing outing4 = new Outing(Outing.Type.bowling, DateTime.Parse("01/05/2020"), 10, 20);
            Outing outing5 = new Outing(Outing.Type.bowling, DateTime.Parse("03/28/2020"), 25, 15);
            Outing outing6 = new Outing(Outing.Type.bowling, DateTime.Parse("10/02/2020"), 40, 12.50m);
            Outing outing7 = new Outing(Outing.Type.concert, DateTime.Parse("02/14/2020"), 17, 45.95m);
            Outing outing8 = new Outing(Outing.Type.concert, DateTime.Parse("07/04/2020"), 35, 72.50m);
            Outing outing9 = new Outing(Outing.Type.concert, DateTime.Parse("09/07/2020"), 12, 225.95m);
            Outing outing10 = new Outing(Outing.Type.golf, DateTime.Parse("05/12/2020"), 4, 45);
            Outing outing11 = new Outing(Outing.Type.golf, DateTime.Parse("07/22/2020"), 8, 39.95m);
            Outing outing12 = new Outing(Outing.Type.golf, DateTime.Parse("09/06/2020"), 12, 34.95m);
            _outingList.AddOuting(outing1);
            _outingList.AddOuting(outing2);
            _outingList.AddOuting(outing3);
            _outingList.AddOuting(outing4);
            _outingList.AddOuting(outing5);
            _outingList.AddOuting(outing6);
            _outingList.AddOuting(outing7);
            _outingList.AddOuting(outing8);
            _outingList.AddOuting(outing9);
            _outingList.AddOuting(outing10);
            _outingList.AddOuting(outing11);
            _outingList.AddOuting(outing12);
        }
    }
}
