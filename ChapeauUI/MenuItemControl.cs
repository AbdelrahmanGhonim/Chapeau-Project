using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class MenuItemControl : UserControl
    {
        public int MenuItemId { get; private set; }

        public string Name
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        public event EventHandler<MenuItemControl> MenuItemClicked;

        public MenuItemControl()
        {
            InitializeComponent();
            this.Click += MenuItemControl_Click;
        }

        private void MenuItemControl_Click(object sender, EventArgs e)
        {
            MenuItemClicked?.Invoke(this, this);
        }

        public void SetMenuItem(int menuItemId, string name, decimal price)
        {
            this.MenuItemId = menuItemId;
            this.Name = name;
            this.Price = price.ToString("C", new CultureInfo("nl-NL"));
        }
    }

}
