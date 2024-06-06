﻿using System;
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
            new SqlParameter("@menuType", SqlDbType.NVarChar) { Value = menuItemType.ToString() }
            };

            try
            {
                DataTable resultTable = ExecuteSelectQueryWithParameters(sql, sqlParameters);
                var result = ReadMenuTables(resultTable);

                Console.WriteLine("SQL Query: " + sql);
                Console.WriteLine("Retrieved " + result.Count + " items for menu type " + menuItemType);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                throw;
            }
        }

        private MenuItemType ConvertStringToMenuItemType(string menuItemType)
        {
            return menuItemType switch
            {
                "Lunch" => MenuItemType.Lunch,
                "Dinner" => MenuItemType.Dinner,
                "Drink" => MenuItemType.Drink,
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
