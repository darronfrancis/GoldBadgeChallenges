using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealIngredients { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }

        public Menu(int mealNumber, string mealName, string mealIngredients, string mealDescription, decimal mealPrice)
        {
            MealNumber = MealNumber;
            MealName = mealName;
            MealIngredients = mealIngredients;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }

        public Menu() { }
    }
}
