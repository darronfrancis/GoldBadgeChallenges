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
            //Badge newBadge = new Badge(600, "Matilda", new List<string>() { "M3", "M5" } );
            item.AddNewBadge(newBadge.BadgeID, List<Badge>);
        }
    }
}
