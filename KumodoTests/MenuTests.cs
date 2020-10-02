using System;
using System.Collections.Generic;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KumodoCafeTests
{
    [TestClass]
    public class UnitTest1
    {
        MenuRepository item = new MenuRepository();

        [TestMethod]
        public void NewMenu()
        {
            Menu newMenuItem = new Menu(1, "Big Mac Combo Meal", new List<string>() { "Big Mac Bun", "100% Beef Patty", "Shredded Lettuce", "Big Mac Sauce", "American Cheese", "Pickle Slices" }, "The one and only McDonald’s Big Mac Combo Meal. Big Mac Ingredients include a classic sesame hamburger bun, Big Mac Sauce, American cheese and sliced pickles. The Big Mac Combo Meal is served with our World Famous Fries and your choice of an icy Coca-Cola fountain drink.", 6.99m);
            
            item.AddMenuItem(newMenuItem);
        }

        [TestMethod]
        public void GetMenu()
        {
            item.GetMenuItem();
        }

        [TestMethod]
        public void DeleteMenuItem()
        {
            item.DeleteMenuItem(1);
        }    
    }
}
