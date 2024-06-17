using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class OrderService
    {
        private OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }

        public List<OrderItem> getOrderItems(Table table)
        {
            return orderDao.GetOrderItems(table);
        }

        public void UpdateOrderItemStatus(OrderItem item)
        {
            orderDao.UpdateOrderItemStatus(item);
        }
        public void AddOrderItem(Order order)
        {
             orderDao.AddOrderItems(order);
        }
   
        public void AddOrder(Order order)
        {
            orderDao.AddOrder(order);
        }
    }
}
