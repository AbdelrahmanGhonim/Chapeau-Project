using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Table Table { get; set; }
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Order(int orderId, Table table, Employee employee, List<OrderItem> orderItems, DateTime orderDateTime)
        {
            OrderId = orderId;
            Table = table;
            Employee = employee;
            OrderItems = orderItems;
            OrderDateTime = orderDateTime;
        }

    }
}
