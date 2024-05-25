﻿using System;
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
        public Table TableNumber { get; set; }
        public int BillID { get; set; } // Bill object
        public List<OrderItem>orderItems { get; set; }

    }
}