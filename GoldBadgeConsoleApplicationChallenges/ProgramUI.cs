using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        private MenuRepository _menuList = new MenuRepository();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Menu Item\n" +
                    "2. See All Menu Items\n" +
                    "3. Delete a Menu Item\n" +
                    "4. Quit");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        SeeAllMenuItems();
                        break;
                    case 3:
                        DeleteMenuItem();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();
            Menu newMenu = new Menu();

            Console.WriteLine("Meal Number:");
            newMenu.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Meal Name:");
            newMenu.MealName = Console.ReadLine();
            Console.WriteLine("Meal Ingredients:");
            newMenu.MealIngredients = Console.ReadLine();
            Console.WriteLine("Meal Description:");
            newMenu.MealDescription = Console.ReadLine();
            Console.WriteLine("Meal Price:");
            newMenu.MealPrice = decimal.Parse(Console.ReadLine());

            _menuList.AddMenuItem(newMenu);

            Console.WriteLine($"Menu item created.\n" +
                $"Meal Number: {newMenu.MealNumber}\n" +
                $"Meal Name: {newMenu.MealName}\n" +
                $"Meal Ingredients: {newMenu.MealIngredients}\n" +
                $"Meal Description: {newMenu.MealDescription}\n" +
                $"Meal Price: ${newMenu.MealPrice}\n" +
                $"Press any key to continue.");
            Console.ReadKey();
        }

        private void SeeAllMenuItems()
        {
            Console.Clear();
            List<Menu> menuItem = _menuList.GetMenuItem();
            foreach (Menu item in menuItem)
            {
                Console.WriteLine($"\nMeal Number: {item.MealNumber}\n" +
                $"Meal Name: {item.MealName}\n" +
                $"Meal Ingredients: {item.MealIngredients}\n" +
                $"Meal Description: {item.MealDescription}\n" +
                $"Meal Price: ${item.MealPrice}\n");
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Menu food = new Menu();
            List<Menu> menuItem = _menuList.GetMenuItem();
            foreach (Menu item in menuItem)
            {
                Console.WriteLine($"{item.MealNumber} - Meal Name: {item.MealName}");
            }
            Console.WriteLine("\n" +
                "What's the name of the meal you would like to remove?");
            string choice = Console.ReadLine();
            _menuList.DeleteMenuItem(choice);
        }
    }
}
