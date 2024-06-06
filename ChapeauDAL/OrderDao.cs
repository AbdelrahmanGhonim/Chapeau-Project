using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {
        public List<OrderItem> GetOrderItems(Table table) //TODO: don't use the * 
        {
            string query = "  SELECT oi.*" +
                    " FROM [dbo].[ORDER] o      " +
                    " JOIN [dbo].[orderItems] oi ON o.orderID = oi.orderID " +
                    " WHERE o.tableNumber = @tableNumber";

                    SqlParameter[] parameters = new SqlParameter[1]// check it later
              {
                    new SqlParameter("@tableNumber", table.TableNumber)
              };

            return ReadOrderItems(ExecuteSelectQueryWithParameters(query, parameters));


        }


        public void UpdateOrderItemStatus(OrderItem item)
        {
            string updateQuery = "UPDATE orderItems SET OrderStatus = @OrderStatus WHERE itemID = @itemID";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
            new SqlParameter("@OrderStatus", item.OrderStatus.ToString()),
            new SqlParameter("@itemID", item.ItemID)
            };

            ExecuteEditQuery(updateQuery, sqlParameters);
        }

        private List<OrderItem> ReadOrderItems(DataTable data)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (DataRow dataRow in data.Rows)
            {
                OrderItem item = new OrderItem()
                {
                    ItemID = (int)dataRow["itemID"],
                    OrderId = (int)dataRow["orderID"],
                    Quantity = (int)dataRow["quantity"],
                    StockQuantity = (int)dataRow["stockQuantity"],
                    ItemName = (string)dataRow["orderName"],
                    OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), (string)dataRow["OrderStatus"]),
                    Price = (decimal)dataRow["price"],
                    VatType = (decimal)dataRow["VAT"],
                    PreprationTime = TimeOnly.FromDateTime(DateTime.Today.Add((TimeSpan)dataRow["PreparationTime"])),
                    Comments = (string)dataRow["Comment"],
                    MenuType = (MenuType)Enum.Parse(typeof(MenuType), (string)dataRow["MenuType"])
                };
                orderItems.Add(item);
            }
            return orderItems;

        }
    }
}
