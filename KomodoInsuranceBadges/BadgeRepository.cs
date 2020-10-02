using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>()
        {
            
        };

        public void AddNewBadge(int badgeID, string badgeName, List<string> doorNames)
        {
            Badge newBadge = new Badge(badgeID, badgeName, doorNames);
            badgeDictionary.Add(newBadge.BadgeID, newBadge);
        }

        public List<Badge> ViewBadges()
        {
            var items = badgeDictionary.Values.ToList();
            return items;
        }

        public bool UpdateDoorsOnBadge(int badgeID, Badge newContent)
        {
            Badge oldContent = GetBadgeByID(badgeID); 
            if (oldContent != null)
            {
                oldContent.DoorNames = newContent.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBadge(int ID)
        {
            Badge badge = GetBadgeByID(ID);
            int initialCount = badge.DoorNames.Count;
            if (badge.BadgeID == ID)
            {
                badge.DoorNames = new List<string>() { };
            }
            else
            {
                Console.WriteLine("There's no badge associated with that ID.");
            }
            if (initialCount > badge.DoorNames.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Badge GetBadgeByID(int ID)
        {
            Badge value;
            if (badgeDictionary.ContainsKey(ID))
            {
                value = badgeDictionary[ID];
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
