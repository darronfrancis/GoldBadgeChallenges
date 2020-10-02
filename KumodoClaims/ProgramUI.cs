using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ProgramUI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();
        
        public void Run()
        {
            SeedMethod();
            Menu();
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims.\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        HandleClaim();
                        break;
                    case 3:
                        AddClaim();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Claim ID:");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Claim Type (1. Car, 2. Home, 3. Theft):");
            int claimType = int.Parse(Console.ReadLine());
            if (claimType == 1)
            {
                _ = newClaim.ClaimType == Claim.Type.Car;
            }
            else if (claimType == 2)
            {
                _ = newClaim.ClaimType == Claim.Type.Home;
            }
            else if (claimType == 3)
            {
                _ = newClaim.ClaimType == Claim.Type.Theft;
            }
            Console.WriteLine("Claim Description:");
            newClaim.ClaimDescription = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Accident:");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Date of Claim:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            
            TimeSpan duration = newClaim.DateOfClaim.Subtract(newClaim.DateOfIncident);
            TimeSpan durationLimit = new TimeSpan(30, 0, 0, 0);
            if (duration <= durationLimit)
            {
                newClaim.IsValid = true;
                Console.WriteLine("Valid Claim: true");
            }
            else
            {
                Console.WriteLine("Valid Claim: false");
            }

            _claimRepository.AddClaim(newClaim);
            
            Console.WriteLine("Claim created.  Press any key to continue.");
            Console.ReadKey();
        }

        private void HandleClaim()
        {
            Console.Clear();
            Claim nextClaim = _claimRepository.NextClaim();
            if (nextClaim != null)
            {
                Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                    $"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Type: {nextClaim.ClaimType}\n" +
                    $"Description: {nextClaim.ClaimDescription}\n" +
                    $"Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Accident: {nextClaim.DateOfIncident.ToString("MM/dd/yy")}\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yy")}\n" +
                    $"Claim is Valid: {nextClaim.IsValid}\n" +
                    $"");

                Console.WriteLine("Do you want to deal with this claim now (y/n)?");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "y":
                        _claimRepository.RemoveClaim();
                        break;
                    case "n":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no claims to handle at this point.");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> listOfClaims = _claimRepository.GetClaim();
            Console.WriteLine("ClaimID * Type * Description * Amount * DateOfAccident * DateOfClaim * IsValid");
            foreach (Claim item in listOfClaims)
            {
                Console.WriteLine($"{ item.ClaimID} * {item.ClaimType} * {item.ClaimDescription} * {item.ClaimAmount} * {item.DateOfIncident.ToString("MM/dd/yy")} * {item.DateOfClaim.ToString("MM/dd/yy")} * {item.IsValid}");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }

        private void SeedMethod()
        {
            Claim newClaim1 = new Claim(123, Claim.Type.Car, "Tree Branch", 1472.23m, DateTime.Parse("04/23/2020"), DateTime.Parse("04/25/2020"), true);
            Claim newClaim2 = new Claim(124, Claim.Type.Theft, "Stolen Purse", 422.85m, DateTime.Parse("05/15/2020"), DateTime.Parse("06/25/2020"), false);
            Claim newClaim3 = new Claim(125, Claim.Type.Home, "Kitchen Fire", 7389.45m, DateTime.Parse("08/17/2020"), DateTime.Parse("08/18/2020"), true);
            _claimRepository.AddClaim(newClaim1);
            _claimRepository.AddClaim(newClaim2);
            _claimRepository.AddClaim(newClaim3);
        }
    }
}
