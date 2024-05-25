using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItem
    {
        public int ItemID { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
        public string ItemName { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Price { get; set; }
        public decimal VatType { get; set; }
        public TimeOnly PreprationTime { get; set; }
        public string Comments { get; set; }
        public MenuType MenuType { get; set; }


    }
}
