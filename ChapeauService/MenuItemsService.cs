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
        public int GetCurrentStock(int itemId)
        {
             return menuItemsDao.GetCurrentStock(itemId);
        }
        public List<MenuItem> GetMenuItemsByType(MenuItemType menuItemType)
        {
            return menuItemsDao.GetMenuItemsByType(menuItemType);
        }
    }
}
