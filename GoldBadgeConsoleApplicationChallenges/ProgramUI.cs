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
            SeedList();
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
            Console.WriteLine("Meal Ingredients (separated by commas):");
            string joined = string.Join(",", Console.ReadLine());
            newMenu.MealIngredients = new List<string>() { joined };
            Console.WriteLine("Meal Description:");
            newMenu.MealDescription = Console.ReadLine();
            Console.WriteLine("Meal Price:");
            newMenu.MealPrice = decimal.Parse(Console.ReadLine());

            _menuList.AddMenuItem(newMenu);

            Console.WriteLine($"Menu item created.\n" +
                $"Meal Number: {newMenu.MealNumber}\n" +
                $"Meal Name: {newMenu.MealName}\n" +
                $"Meal Ingredients: {joined}\n" +
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
                string joined = string.Join(",", item.MealIngredients);
                Console.WriteLine($"\nMeal Number: {item.MealNumber}\n" +
                $"Meal Name: {item.MealName}\n" +
                $"Meal Ingredients: {joined}\n" +
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
                "What's the number of the meal you would like to remove?");
            int choice = int.Parse(Console.ReadLine());
            _menuList.DeleteMenuItem(choice);
        }
        private void SeedList()
        {
            Menu newMenuItem1 = new Menu(1, "Big Mac Combo Meal", new List<string>() { "Big Mac Bun, 100% Beef Patty, Shredded Lettuce, Big Mac Sauce, American Cheese, Pickle Slices" }, "The one and only McDonald’s Big Mac Combo Meal. Big Mac Ingredients include a classic sesame hamburger bun, Big Mac Sauce, American cheese and sliced pickles. The Big Mac Combo Meal is served with our World Famous Fries and your choice of an icy Coca-Cola fountain drink.", 6.99m);
            Menu newMenuItem2 = new Menu(2, "Quarter Pounder with Cheese", new List<string>() { "Quarter Pound 100% Beef Patty, Quarter Pound Bun, Pasteurized Process American Cheese, Ketchup, Pickle Slices, Onions, Mustard" }, "TheEach Quarter Pounder with Cheese burger features a ¼ lb.* of 100% fresh beef that’s hot, deliciously juicy and cooked when you order. It’s seasoned with just a pinch of salt and pepper, sizzled on a flat iron grill, then topped with slivered onions, tangy pickles and two slices of melty cheese on a sesame seed bun. Our QPC contains no artificial flavors, preservatives or added colors from artificial sources. **Our pickle contains an artificial preservative, so skip it if you like.", 5.99m);
            Menu newMenuItem3 = new Menu(3, "McDouble", new List<string>() { "100% Beef Patty, Regular Bun, Pasteurized Process American Cheese, Pickle Slices, Ketchup, Onions, Grill Seasoning" }, "A classic double burger from McDonald’s, the McDouble stacks two 100% pure beef patties seasoned with just a pinch of salt and pepper. It’s topped with tangy pickles, chopped onions, ketchup, mustard and a slice of melty American cheese. It contains no artificial flavors, preservatives or added colors from artificial sources.* Our pickle contains an artificial preservative, so skip it if you like.", 6.99m);

            _menuList.AddMenuItem(newMenuItem1);
            _menuList.AddMenuItem(newMenuItem2);
            _menuList.AddMenuItem(newMenuItem3);
        }
    }
}
