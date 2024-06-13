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
        public string ItemName { get; set; } //menuItem object
        public OrderStatus OrderStatus { get; set; }
        public decimal Price { get; set; } //menuItem object
        public decimal VatType { get; set; }
        public TimeSpan PreparationTime { get; set; } //TODO: you have to show to time prepration in the table view
        public string Comments { get; set; }
        public MenuType MenuType { get; set; } //menuItem object
        public DateTime ItemPlacedTime { get; set; }


    }
}
