using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int OrderId { get; set; }
        public string Comment { get; set; }
        public int Amount { get; set; }
        public DateTime OrderTime { get; set; }
        public Category Category { get; set; }

        public OrderItem(MenuItem menuItem, int amount, DateTime dateTime, string comment)
        {
            MenuItem = menuItem;
            Amount = amount;
            OrderTime = dateTime;
            Comment = comment;
        }

    }
}
