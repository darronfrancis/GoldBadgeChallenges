using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimRepository
    {
        private Queue<Claim> _listOfClaims = new Queue<Claim>();

        //CREATE
        public void AddClaim(Claim item)
        {
            _listOfClaims.Enqueue(item);
        }

        //READ
        public Queue<Claim> GetClaim()
        {
            return _listOfClaims;
        }

        //UPDATE
        public bool UpdateClaim(int claimID, Claim newContent)
        {
            // Find the content
            Claim oldContent = GetClaimByID(claimID);
            
            //Update the content
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.ClaimType = newContent.ClaimType;
                oldContent.ClaimDescription = newContent.ClaimDescription;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                oldContent.IsValid = newContent.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveClaim()
        {
            int initialCount = _listOfClaims.Count;
            _listOfClaims.Dequeue();

            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public Claim GetClaimByID(int number)
        {
            foreach (Claim item in _listOfClaims)
            {
                if (item.ClaimID == number)
                {
                    return item;
                }
            }
            return null;
        }

        public Claim NextClaim()
        {
            if (_listOfClaims.Count > 0)
            {
                return _listOfClaims.First();
            }
            else
            {
                return null;
            }
        }
    }
}
