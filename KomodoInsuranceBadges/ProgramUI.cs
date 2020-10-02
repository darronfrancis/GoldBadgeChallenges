using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    class ProgramUI
    {
        private BadgeRepository _badgeList = new BadgeRepository();

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
                Console.WriteLine("What would you like to do?\n" +
                    "1. Create a Badge\n" +
                    "2. Update Doors on a Badge\n" +
                    "3. Delete All Doors on a Badge\n" +
                    "4. View Current Badges\n" +
                    "5. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                    case 3:
                        DeleteBadgeDoors();
                        break;
                    case 4:
                        ListBadges();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ListBadges()
        {
            Console.Clear();
            List<Badge> listOfBadges = _badgeList.ViewBadges();
            Console.WriteLine("Badge ID * Doors");
            foreach (Badge item in listOfBadges)
            {
                if (item != null)
                {
                    string joined = string.Join(",", item.DoorNames);
                    string.Join(", ", listOfBadges);
                    Console.WriteLine($"{item.BadgeID} * {joined}");
                }
                else
                {
                    Console.WriteLine("You currently don't have any badges.");
                }
            }

            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void AddBadge()
        {
            Dictionary<int, Badge> newBadge = new Dictionary<int, Badge>();
            Console.Clear();
            Console.WriteLine("Badge Number:");
            int badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Badge Name:");
            string badgeName = Console.ReadLine();
            Console.WriteLine("Number of Doors Badge can Access:");
            int doorNumber = int.Parse(Console.ReadLine());
            List<string> accessibleDoors = new List<string>();
            for (int i = 1; i <= doorNumber; i++)
            {
                Console.WriteLine($"Door Name #{i}:");
                accessibleDoors.Add(Console.ReadLine());
            }

            _badgeList.AddNewBadge(badgeID, badgeName, accessibleDoors);

            Console.Clear();
            Console.WriteLine("Current Badge List");
            List<Badge> listOfBadges = _badgeList.ViewBadges();
            Console.WriteLine("Badge ID * Doors");
            foreach (Badge item in listOfBadges)
            {
                if (item != null)
                {
                    string joined = string.Join(",", item.DoorNames);
                    string.Join(", ", listOfBadges);
                    Console.WriteLine($"{item.BadgeID} * {joined}");
                }
                else
                {
                    Console.WriteLine("You currently don't have any badges.");
                }
            }
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        private void UpdateBadge()
        {
            Console.Clear();
            List<Badge> listOfBadges = _badgeList.ViewBadges();
            Console.WriteLine("Badge ID * Doors");
            foreach (Badge item in listOfBadges)
            {
                if (item != null)
                {
                    string joined = string.Join(",", item.DoorNames);
                    string.Join(", ", listOfBadges);
                    Console.WriteLine($"{item.BadgeID} * {joined}");
                }
                else
                {
                    Console.WriteLine("You currently don't have any badges.");
                }
            }

            Console.WriteLine("\nWhich badge would you like to update?\n" +
                "Badge ID:");
            int badgeID = int.Parse(Console.ReadLine());

            Badge content = _badgeList.GetBadgeByID(badgeID);
            
            Console.Clear();
            if (content == null)
            {
                Console.WriteLine("There is no badge with this ID.");
            }
            else
            {
                Console.WriteLine($"You are editing info for Badge {badgeID}.  Number of Doors Attached to this Badge:");
                int doorNumber = int.Parse(Console.ReadLine());
                List<string> accessibleDoors = new List<string>();
                for (int i = 1; i <= doorNumber; i++)
                {
                    Console.WriteLine($"Door Name #{i}:");
                    accessibleDoors.Add(Console.ReadLine());
                }
                string joined = string.Join(",", accessibleDoors);
                Badge badge1 = new Badge(content.BadgeID, content.BadgeName, new List<string>() {joined});
                _badgeList.UpdateDoorsOnBadge(content.BadgeID, badge1);
                Console.WriteLine("\nYour badge has been updated.");
            }

            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteBadgeDoors()
        {
            Console.Clear();
            List<Badge> listOfBadges = _badgeList.ViewBadges();
            Console.WriteLine("Badge ID * Doors");
            foreach (Badge item in listOfBadges)
            {
                if (item != null)
                {
                    string joined = string.Join(",", item.DoorNames);
                    string.Join(", ", listOfBadges);
                    Console.WriteLine($"{item.BadgeID} * {joined}");
                }
                else
                {
                    Console.WriteLine("You currently don't have any badges.");
                }
            }
            Console.WriteLine("\nWhat is the ID of the badge on which you would like to delete doors?");
            int badgeID = int.Parse(Console.ReadLine());
            Badge content = _badgeList.GetBadgeByID(badgeID);
            _badgeList.DeleteBadge(badgeID);

            Console.Clear();
            Console.WriteLine("Current List of Badges");
            Console.WriteLine("Badge ID * Doors");
            foreach (Badge item in listOfBadges)
            {
                if (item != null)
                {
                    string joined = string.Join(",", item.DoorNames);
                    string.Join(", ", listOfBadges);
                    Console.WriteLine($"{item.BadgeID} * {joined}");
                }
                else
                {
                    Console.WriteLine("You currently don't have any badges.");
                }
            }
            Console.WriteLine($"\nPress any key to continue...");
            Console.ReadKey();
        }

        public void Seed()
        {

            Badge badge1 = new Badge(101, "Alexandria", new List<string>() { "A3", "A5" });
            Badge badge2 = new Badge(102, "Olympia", new List<string>() { "A2", "A3", "A4" });
            Badge badge3 = new Badge(103, "Persia", new List<string>() { "A1", "A4", "A5" });
            _badgeList.AddNewBadge(badge1.BadgeID, badge1.BadgeName, badge1.DoorNames);
            _badgeList.AddNewBadge(badge2.BadgeID, badge2.BadgeName, badge2.DoorNames);
            _badgeList.AddNewBadge(badge3.BadgeID, badge3.BadgeName, badge3.DoorNames);
        }
    }
}
