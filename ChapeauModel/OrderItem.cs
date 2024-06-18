using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChapeauModel
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Comments { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public DateTime ItemPlacedTime { get; set; }


        public OrderItem()
        {
            Quantity = 1;
            Comments = "";
        }
 
        public OrderItem(MenuItem menuItem)
        {
            MenuItem = menuItem;
            Quantity = 1;
            Comments = "";
        }


    }
}
