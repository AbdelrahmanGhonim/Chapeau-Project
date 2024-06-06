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

        public MenuItemControl()
        {
            InitializeComponent();
            this.Click += MenuItemControl_Click;
            lblName.Click += MenuItemControl_Click; 
            lblPrice.Click += MenuItemControl_Click; 
        }

        public void SetMenuItem(int menuItemId, string name, decimal price)
        {
            this.MenuItemId = menuItemId;
            Name = name;
            Price = price.ToString("C", CultureInfo.CreateSpecificCulture("de-DE"));
        }

        private void MenuItemControl_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray; 
            OnMenuItemClicked(this);
        }

        public event EventHandler<MenuItemControl> MenuItemClicked;

        protected virtual void OnMenuItemClicked(MenuItemControl menuItemControl)
        {
            MenuItemClicked?.Invoke(this, menuItemControl);
        }
    }


}
