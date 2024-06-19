using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class MenuItemsDao : BaseDao
    {
        public List<MenuItem> GetMenuItemsByType(MenuItemType menuItemType)
        {
            string sql = "SELECT mi.itemID, mi.menuId, mi.name, mi.price, mi.stockLeft, mi.menuCategory, m.menuType " +
                         "FROM menuItem mi " +
                         "INNER JOIN menu m ON mi.menuId = m.id " +
                         "WHERE m.menuType = @menuType";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@menuType", menuItemType.ToString())
            };

            DataTable resultTable = ExecuteSelectQueryWithParameters(sql, sqlParameters);
            return ReadMenuTables(resultTable);
        }
        public void UpdateStock(int itemId, int quantity)
        {
            string query = "UPDATE menuItem SET stockLeft = stockLeft - @Quantity WHERE itemID = @ItemId";

            SqlParameter[] parameters = {
            new SqlParameter("@Quantity", quantity),
            new SqlParameter("@ItemId", itemId)
        };

            ExecuteEditQuery(query, parameters);
        }

        public int GetCurrentStock(int itemId)
        {
            string query = "SELECT stockLeft FROM menuItem WHERE itemID = @ItemId";

            SqlParameter[] parameters = {
            new SqlParameter("@ItemId", itemId)
            };

            return ExecuteScalarQuery<int>(query, parameters, 0);
        }
        public MenuItem GetMenuItemById(int itemId)
        {
            string sql = "SELECT mi.itemID, mi.menuId, mi.name, mi.price, mi.stockLeft, mi.menuCategory, m.menuType " +
                         "FROM menuItem mi " +
                         "INNER JOIN menu m ON mi.menuId = m.id " +
                         "WHERE mi.itemID = @itemId";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ItemId", itemId)
            };

            DataTable resultTable = ExecuteSelectQueryWithParameters(sql, sqlParameters);
            var result = ReadMenuTables(resultTable);

            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                throw new Exception($"No menu item found with ID {itemId}");
            }

        }
        private MenuItemType ConvertStringToMenuItemType(string menuItemType)
        {
            return menuItemType switch
            {
                "Lunch" => MenuItemType.Lunch,
                "Dinner" => MenuItemType.Dinner,
                "Drinks" => MenuItemType.Drinks,
                _ => throw new Exception($"Exception menu item type {menuItemType} is not known")
            };
        }

        private Category ConvertStringToCategory(string category)
        {
            return category switch
            {
                "Starters" => Category.Starters,
                "MainDishes" => Category.MainDishes,
                "Entremets" => Category.Entremets,
                "Desserts" => Category.Desserts,
                "SoftDrinks" => Category.SoftDrinks,
                "BeersOnTap" => Category.BeersOnTap,
                "Wines" => Category.Wines,
                "SpiritDrinks" => Category.SpiritDrinks,
                "CoffeeTea" => Category.CoffeeTea,
                _ => throw new Exception($"Exception category {category} is not known")
            };
        }

        private List<MenuItem> ReadMenuTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            try
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    MenuItem menuItem = new MenuItem()
                    {
                        ItemId = (int)dr["itemID"],
                        MenuId = (int)dr["menuId"],
                        Name = (string)dr["name"],
                        Price = (decimal)dr["price"],
                       // VAT = (decimal)dr["vat"],
                        Stock = dr["stockLeft"] != DBNull.Value ? (int?)dr["stockLeft"] : null,
                        MenuItemType = ConvertStringToMenuItemType((string)dr["menuType"]),
                        Category = ConvertStringToCategory((string)dr["menuCategory"])
                    };
                    menuItems.Add(menuItem);

                    Console.WriteLine($"Added MenuItem: {menuItem.Name}, {menuItem.Price}, {menuItem.Category}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading menu tables: " + ex.Message);
            }

            return menuItems;
        }

    }

}
