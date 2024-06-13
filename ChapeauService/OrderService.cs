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

        public List<OrderItem> GetOrderItems(Table table)
        { 
        return orderDao.GetOrderItems(table);
        }

        public void UpdateOrderItemStatus(OrderItem item)
        {
             
            orderDao.UpdateOrderItemStatus(item);
        }
    }
}
