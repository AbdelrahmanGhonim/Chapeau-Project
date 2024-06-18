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
        private  MenuItemsDao menuItemsDao;
        private TableDao tableDao;

        public OrderDao()
        {
               menuItemsDao = new MenuItemsDao();
                 tableDao = new TableDao();

        }
        public List<OrderItem> GetOrderItems(Table table)
        {
            string query = "SELECT oi.itemID, mi.name AS ItemName, oi.OrderStatus, mi.PreparationTime, o.OrderDateTime " +
                   "FROM [dbo].[OrderedItems] oi " +
                   "JOIN [dbo].[menuItem] mi ON oi.itemID = mi.itemID " +
                   "JOIN [dbo].[ORDER] o ON oi.orderID = o.orderID " +
                   "WHERE o.tableNumber = @tableNumber";

            SqlParameter[] parameters = new SqlParameter[1]
      {
                    new SqlParameter("@tableNumber", table.TableNumber)
      };

            return ReadOrderItems(ExecuteSelectQueryWithParameters(query, parameters));


        }

        public void UpdateOrderItemStatus(OrderItem item)
        {
            string updateQuery = "UPDATE OrderedItems SET OrderStatus = @OrderStatus WHERE itemID = @itemID";

            SqlParameter[] sqlParameters = new SqlParameter[2]
            {
            new SqlParameter("@OrderStatus", item.OrderStatus.ToString()),
            new SqlParameter("@itemID", item.MenuItem.ItemId)
            };

            ExecuteEditQuery(updateQuery, sqlParameters);
        }


        public void AddOrder(Order order)
        {
            string query = "INSERT INTO [dbo].[Order] (tableNumber, orderDateTime, employee) " +
                           "VALUES (@tableNumber, @orderDateTime, @employee); " +
                           "SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tableNumber", order.TableNumber.TableNumber),
                new SqlParameter("@orderDateTime", order.OrderTime),
                new SqlParameter("@employee", order.Employee.EmployeeId)
            };

            int orderId = ExecuteScalarQuery<int>(query, parameters);
            order.OrderID = orderId;

            foreach (OrderItem item in order.OrderedItems)
            {
                if (item.Order == null)
                {
                    item.Order = new Order();
                }

                item.Order.OrderID = orderId;
            }

            AddOrderItems(order);

            order.TableNumber.Status = TableStatus.Ordered;
            tableDao.UpdateTableStatus(order.TableNumber);
        }


        public void AddOrderItems(Order order)
        {
            try
            {
                foreach (OrderItem item in order.OrderedItems)
                {
                    string query = "INSERT INTO [dbo].[OrderedItems] (orderID, itemID, quantity, comment) " +
                                   "VALUES (@orderID, @itemID, @quantity, @comment)";

                    SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                    new SqlParameter("@orderID", item.Order.OrderID),
                    new SqlParameter("@itemID", item.MenuItem.ItemId),
                    new SqlParameter("@quantity", item.Quantity),
                    new SqlParameter("@comment", item.Comments)
                    };

                    ExecuteEditQuery(query, sqlParameters);

                    menuItemsDao.UpdateStock(item.MenuItem.ItemId, item.Quantity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding order items: {ex.Message}");
            }
        }


        private List<OrderItem> ReadOrderItems(DataTable data)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (DataRow dataRow in data.Rows)
            {
                OrderItem item = new OrderItem()
                {
                    /*OrderItemId = (int)dataRow["orderItemID"],*/
                    MenuItem = new MenuItem { Name = (string)dataRow["ItemName"],// 
                        PreparationTime = (TimeSpan)dataRow["PreparationTime"],
                        ItemId = (int)dataRow["itemID"],
                    },
                    OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), dataRow["OrderStatus"].ToString()),
                    Order = new Order { OrderTime = (DateTime)dataRow["orderDateTime"] }
                };
                orderItems.Add(item);
            }
            return orderItems;
        }
    }
}
