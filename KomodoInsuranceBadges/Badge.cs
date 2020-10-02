using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string BadgeName { get; set; }

        public Badge() { }

        public Badge(int badgeID, string badgeName, List<string> doorNames)
        {
            BadgeID = badgeID;
            BadgeName = badgeName;
            DoorNames = doorNames;
        }

        public Badge(int badgeID, List<string> doorNames)
        {
            DoorNames = doorNames;
        }
    }
}
