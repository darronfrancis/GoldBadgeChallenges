using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue
{
    class DessertBooth : Booth
    {
        public enum DessertType { iceCream, popcorn}

        public DessertType TypeOfDessert { get; set; }
        public decimal Toppings { get; set; }
        public int DessertTicket { get; set; }

        public DessertBooth(DessertType typeOfDessert, int dessertTicket, decimal toppings, int employees, decimal totalUtensilsCost, decimal totalNapkinsCost, decimal totalDishesCost)
        {
            TypeOfDessert = typeOfDessert;
            DessertTicket = dessertTicket;
            Toppings = toppings;
            Employees = employees;
            TotalUtensilsCost = totalUtensilsCost;
            TotalNapkinsCost = totalNapkinsCost;
            TotalDishesCost = totalDishesCost;
        }
    }
}
