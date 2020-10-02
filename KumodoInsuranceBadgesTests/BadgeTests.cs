using System;
using System.Collections.Generic;
using KomodoInsuranceBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoInsuranceBadgesTests
{
    [TestClass]
    public class BadgeTests
    {
        BadgeRepository item = new BadgeRepository();
        
        [TestMethod]
        public void AddNewBadge()
        {
            Badge newBadge = new Badge(600, "Matilda", new List<string>() { "M3", "M5" } );
            item.AddNewBadge(newBadge.BadgeID = 600, newBadge.BadgeName, newBadge.DoorNames);
        }
        [TestMethod]
        public void GetBadgeByID()
        {
            Badge newBadge = new Badge(729, "Matilda", new List<string>() { "M3", "M5" });
            item.AddNewBadge(newBadge.BadgeID = 729, newBadge.BadgeName, newBadge.DoorNames);
            item.GetBadgeByID(729);
        }

        [TestMethod]
        public void GetBadgeValues()
        {
            item.ViewBadges();
        }

        [TestMethod]
        public void UpdateDoorsOnBadge()
        {
            Badge newBadge = new Badge(600, "Matilda", new List<string>() { "M3", "M5" });
            item.UpdateDoorsOnBadge(600, newBadge);
        }
    }
}
