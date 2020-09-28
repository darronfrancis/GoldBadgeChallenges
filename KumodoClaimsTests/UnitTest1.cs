using System;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimRepository claim = new ClaimRepository();

        [TestMethod]
        public void NewClaim()
        {
            Claim newClaim = new Claim(123, Claim.Type.Car, "This is a mess.", 1472.23m, DateTime.Parse("04/23/2020"), DateTime.Parse("04/25/2020"), true);
        }

        [TestMethod]
        public void GetClaim()
        {
            claim.GetClaim();
        }

        [TestMethod]
        public void UpdateClaim()
        {
            Claim newClaim = new Claim(123, Claim.Type.Home, "This is more of a mess.", 140782.23m, DateTime.Parse("06/13/2020"), DateTime.Parse("06/25/2020"), true);

            claim.UpdateClaim(123, newClaim);
        }
    }
}
