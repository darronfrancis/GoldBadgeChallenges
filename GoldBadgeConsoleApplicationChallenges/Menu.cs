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
        public List<string> MealIngredients { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }

        public Menu(int mealNumber, string mealName, List<string> mealIngredients, string mealDescription, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealIngredients = mealIngredients;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
        }

        public Menu() { }
    }
}
