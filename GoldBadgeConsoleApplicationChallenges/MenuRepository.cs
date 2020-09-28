using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepository
    {
        private List<Menu> _menuItemsList = new List<Menu>();
        
        //CREATE
        public void AddMenuItem(Menu item)
        {
            _menuItemsList.Add(item);
        }

        //READ
        public List<Menu> GetMenuItem()
        {
            return _menuItemsList;
        }

        //DELETE
        public bool DeleteMenuItem(string item)
        {
            Menu content = GetMenuItemByNumber(item);

            if (content == null)
            {
                return false;
            }

            int initialCount = _menuItemsList.Count;
            _menuItemsList.Remove(content);

            if (initialCount > _menuItemsList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELPER
        public Menu GetMenuItemByNumber(string name)
        { 
            foreach (Menu item in _menuItemsList)
            {
                if (item.MealName == name)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
