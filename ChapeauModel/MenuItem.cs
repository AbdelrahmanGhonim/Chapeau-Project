using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public MenuItemType MenuItemType { get; set; }
        //PreparationTime
        public TimeSpan PreparationTime { get; set; }

        public Category Category { get; set; }

    }
}
