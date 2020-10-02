using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue
{
    class FoodBooth : Booth
    {
        public enum FoodType { burger, veggieBurger, hotDog }

        public FoodType TypeOfFood { get; set; }
        public decimal Condiments { get; set; }
        public int FoodTicket { get; set; }

        public FoodBooth() { }

        public FoodBooth(FoodType typeOfFood, int foodTicket, decimal condiments, int employees, decimal totalUtensilsCost, decimal totalNapkinsCost, decimal totalDishesCost)
        {
            TypeOfFood = typeOfFood;
            FoodTicket = foodTicket;
            Condiments = condiments;
            Employees = employees;
            TotalUtensilsCost = totalUtensilsCost;
            TotalNapkinsCost = totalNapkinsCost;
            TotalDishesCost = totalDishesCost;
        }
    }
}
