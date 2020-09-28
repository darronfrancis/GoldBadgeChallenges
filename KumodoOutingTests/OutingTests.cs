using System;
using KomodoOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoOutingTests
{
    [TestClass]
    public class OutingTests
    {
        OutingRepository content = new OutingRepository();

        [TestMethod]
        public void AddOuting()
        {
            Outing outing1 = new Outing(Outing.Type.amusementPark, DateTime.Parse("09/26/2020"), 30, 7.50m);

            content.AddOuting(outing1);
        }

        [TestMethod]
        public void GetOutings()
        {
            content.GetOuting();
        }

        [TestMethod]
        public void GetOutingByType()
        {
            string type = "golf";
            content.GetOutingByType(type);
        }
    }
}
