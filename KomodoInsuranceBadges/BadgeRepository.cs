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
        private List<Badge> _listOfBadges = new List<Badge>();
        public Dictionary<Badge, Badge> badgeDictionary = new Dictionary<Badge, Badge>()
        {
            { new Badge { BadgeID = 101 }, new Badge { BadgeName="Alexandria", DoorNames = new List<string>() {"A3", "A5"} } },
            { new Badge { BadgeID = 102 }, new Badge { BadgeName="Olympia", DoorNames = new List<string>() {"A2", "A3", "A4"} } },
            { new Badge { BadgeID = 103 }, new Badge { BadgeName="Persia", DoorNames = new List<string>() {"A1", "A4", "A5"} } },
        };

        public void AddNewBadge(Badge item1, Badge item2)
        {
            badgeDictionary.Add(item1, item2);
        }

        public List<Badge> ViewBadges()
        {
            return _listOfBadges;
        }

/*        public Badge UpdateDoorsOnBadge(int ID, List<string>)
        {
            Badge badge = GetBadgeByID(ID);
            badgeDictionary.Add(ID, badge);
            badgeDictionary.Add = badge.DoorNames(List<>);
        }*/

        public Badge GetBadgeByID(int ID)
        {
            foreach (var item in _listOfBadges)
            {
                if(ID == item.BadgeID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
