using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauService;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class OrderConfirmation : Form
    {
        private List<OrderItem> orderedItems;

        public OrderConfirmation(List<OrderItem> items)
        {
            InitializeComponent();
            orderedItems = items;
            DisplayOrderedItems();
        }

        private void DisplayOrderedItems()
        {
            listViewOrderConfirmation.Items.Clear();

            foreach (var orderItem in orderedItems)
            {
                ListViewItem listViewItem = new ListViewItem(orderItem.Amount.ToString());
                listViewItem.SubItems.Add(orderItem.MenuItem.Name);         
                listViewItem.SubItems.Add(orderItem.Comment);                   

                listViewOrderConfirmation.Items.Add(listViewItem);
            }
        }
    }
}
