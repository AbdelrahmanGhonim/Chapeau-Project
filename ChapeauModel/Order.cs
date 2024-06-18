
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderTime { get; set; }
        public Employee Employee { get; set; }
        public Table TableNumber { get; set; }
        public List<OrderItem> OrderedItems { get; set; }

        public Order(){}
        public Order(Table table, Employee employee)
        {
            this.TableNumber = table;
            this.Employee = employee;
            this.OrderedItems = new List<OrderItem>();
            this.OrderTime = DateTime.Now;
        }

    }
}
