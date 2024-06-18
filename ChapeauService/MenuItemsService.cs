using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauService
{
    public class MenuItemsService
    {
        private MenuItemsDao menuItemsDao;

        public MenuItemsService()
        {
            menuItemsDao = new MenuItemsDao();
        }
        public MenuItem GetMenuItemById(int itemId)
        {
            return menuItemsDao.GetMenuItemById(itemId);
        }
        public List<MenuItem> GetMenuItemsByType(MenuItemType menuItemType)
        {
            return menuItemsDao.GetMenuItemsByType(menuItemType);
        }
        private List<Category> GetDrinks()
        {
            List<Category> drinks = new List<Category>();
            drinks.Add(Category.SoftDrinks);
            drinks.Add(Category.BeersOnTap);
            drinks.Add(Category.Wines);
            drinks.Add(Category.SpiritDrinks);
            drinks.Add(Category.CoffeeTea);
            return drinks;
        }

        private List<Category> GetLunch()
        {
            List<Category> lunch = new List<Category>();
            lunch.Add(Category.Starters);
            lunch.Add(Category.MainDishes);
            lunch.Add(Category.Desserts);
            return lunch;
        }
        private List<Category> GetDinner()
        {
            List<Category> dinner = new List<Category>();
            dinner.Add(Category.Starters);
            dinner.Add(Category.Entremets);
            dinner.Add(Category.MainDishes);
            dinner.Add(Category.Desserts);
            return dinner;
        }
        public List<Category> GetMenuItemType(MenuItemType menuItemType)
        {
            switch (menuItemType)
            {
                case MenuItemType.Dinner: return GetDinner();
                case MenuItemType.Lunch: return GetLunch();
                case MenuItemType.Drinks: return GetDrinks();
                default: throw new NotImplementedException();
            }
        }
    }
}
