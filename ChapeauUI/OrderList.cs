using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauDAL;
using ChapeauService;
using ChapeauModel;

namespace ChapeauUI {

    public partial class OrderList : Form
    {
        private MenuItemType selectedMenu;
        private MenuItemControl selectedMenuItemControl;

        public OrderList()
        {
            InitializeComponent();
            this.selectedMenu = MenuItemType.Lunch;

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(lunchBtn);
            listViewOrder.SelectedIndexChanged += listViewOrder_SelectedIndexChanged;
            numQuantity.ValueChanged += numQuantity_ValueChanged;
        }

        private void ShowMenuItems(MenuItemType menuItemType)
        {
            try
            {
                MenuItemsService menuItemsService = new MenuItemsService();
                List<MenuItem> menuItemsList = menuItemsService.GetMenuItemsByType(menuItemType);

                if (menuItemsList.Count == 0)
                {
                    MessageBox.Show("No menu items found for the selected menu type.");
                    return;
                }

                var menuItemsCategories = menuItemsList.Select(mi => mi.Category).Distinct().ToList();

                flowLayoutPanelMenu.Controls.Clear();

                foreach (Category category in menuItemsCategories)
                {
                    AddCategoryHeader(category);
                    DisplayMenuItemsForCategory(menuItemsList, category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error happened in showing menu items: {ex.Message}");
            }
        }

        private void lunchBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Lunch;
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(sender as Button);
        }

        private void MenuItemControl_MenuItemClicked(object sender, MenuItemControl menuItemControl)
        {
            if (selectedMenuItemControl != null)
            {
                selectedMenuItemControl.BackColor = Color.FromArgb(217, 217, 217);
            }

            selectedMenuItemControl = menuItemControl;
            selectedMenuItemControl.BackColor = Color.DarkGray;

            string itemName = selectedMenuItemControl.Name;
            string itemPrice = selectedMenuItemControl.Price;
            string comment = "";

            AddMenuItemToListView(itemName, itemPrice, comment);

            UpdateAddButtonVisibility();
        }

        private void AddMenuItemToListView(string itemName, string itemPrice, string comment)
        {
            bool itemFound = false;

            foreach (ListViewItem item in listViewOrder.Items)
            {
                OrderItem orderItem = (OrderItem)item.Tag;
                if (orderItem.MenuItem.Name == itemName && orderItem.Comment == comment)
                {
                    orderItem.Amount++;
                    item.SubItems[0].Text = orderItem.Amount.ToString();
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                MenuItem menuItem = GetMenuItemByName(itemName);
                if (menuItem != null)
                {
                    OrderItem newOrderItem = new OrderItem(menuItem, 1, DateTime.Now, comment);
                    ListViewItem listViewItem = new ListViewItem(newOrderItem.Amount.ToString());
                    listViewItem.SubItems.Add(newOrderItem.MenuItem.Name);
                    listViewItem.SubItems.Add(newOrderItem.Comment);
                    listViewItem.Tag = newOrderItem;
                    listViewOrder.Items.Add(listViewItem);
                }
                else
                {
                    MessageBox.Show($"MenuItem not found for item: {itemName}");
                }
            }
        }

        private MenuItem GetMenuItemByName(string itemName)
        {
            return new MenuItem
            {
                Name = itemName,
               // Price = 

            };
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            List<OrderItem> orderedItems = new List<OrderItem>();

            foreach (ListViewItem item in listViewOrder.Items)
            {
                OrderItem orderItem = (OrderItem)item.Tag;
                orderedItems.Add(orderItem);
            }

            OrderConfirmation orderSummaryForm = new OrderConfirmation(orderedItems);
            orderSummaryForm.Show();
            this.Hide();
        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ButtonsVisibility();
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                int quantity = int.Parse(selectedItem.SubItems[0].Text);
                numQuantity.Value = quantity;
            }
            else
            {
                ResetButtonVisibility();
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                OrderItem orderItem = (OrderItem)selectedItem.Tag;

                if (numQuantity.Value == 0)
                {
                    listViewOrder.Items.Remove(selectedItem);
                }
                else
                {
                    orderItem.Amount = (int)numQuantity.Value;
                    selectedItem.SubItems[0].Text = orderItem.Amount.ToString();
                }
            }
        }

        private void btnAddComment_Click_1(object sender, EventArgs e)
        {
            pnlComment.Visible = false;

            foreach (Control control in Controls)
            {
                if (control != pnlComment)
                {
                    control.Enabled = true;
                }
            }

            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];
                selectedItem.SubItems[2].Text = txtBoxComment.Text;

                OrderItem orderItem = (OrderItem)selectedItem.Tag;
                orderItem.Comment = txtBoxComment.Text;
            }
        }

        private void btnComment_Click_1(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                if (selectedItem.SubItems.Count >= 3)
                {
                    string currentComment = selectedItem.SubItems[2].Text;

                    pnlComment.Visible = true;

                    foreach (Control control in Controls)
                    {
                        if (control != pnlComment)
                        {
                            control.Enabled = false;
                        }
                    }

                    txtBoxComment.Text = currentComment;
                }
                else
                {
                    MessageBox.Show("The selected item does not have a comment.");
                }
            }
        }

        private void AddCategoryHeader(Category category)
        {
            Label categoryHeader = new Label
            {
                Text = CategoryDisplayName(category),
                Font = new Font("Arial", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Width = flowLayoutPanelMenu.ClientSize.Width,
                Margin = new Padding(0, 10, 0, 10)
            };
            flowLayoutPanelMenu.Controls.Add(categoryHeader);
        }

        private string CategoryDisplayName(Category category)
        {
            return category switch
            {
                Category.Starters => "STARTERS",
                Category.MainDishes => "MAINS",
                Category.Entremets => "ENTREMENTS",
                Category.Desserts => "DESSERTS",
                Category.SoftDrinks => "SOFT DRINKS",
                Category.BeersOnTap => "BEERS ON TAP",
                Category.Wines => "WINES",
                Category.SpiritDrinks => "SPIRIT DRINKS",
                Category.CoffeeTea => "COFFEE / TEA",
                _ => "Unknown"
            };
        }

        private void DisplayMenuItemsForCategory(List<MenuItem> menuItems, Category category)
        {
            var itemsForCategory = menuItems.Where(mi => mi.Category == category).ToList();
            foreach (var menuItem in itemsForCategory)
            {
                MenuItemControl menuItemControl = new MenuItemControl();
                menuItemControl.SetMenuItem(menuItem.ItemId, menuItem.Name, menuItem.Price);
                menuItemControl.MenuItemClicked += MenuItemControl_MenuItemClicked;
                flowLayoutPanelMenu.Controls.Add(menuItemControl);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlComment.Visible = false;

            foreach (Control control in Controls)
            {
                if (control != pnlComment)
                {
                    control.Enabled = true;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                listViewOrder.Items.Remove(selectedItem);
                listViewOrder.SelectedItems.Clear();

                ResetButtonVisibility();
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                pnlComment.Visible = true;

                foreach (Control control in Controls)
                {
                    if (control != pnlComment)
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        private void UpdateAddButtonVisibility()
        {
            addBtn.Visible = listViewOrder.Items.Count > 0;
            btnRemoveAll.Visible = listViewOrder.Items.Count > 0;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            if (selectedMenuItemControl != null)
            {
                selectedMenuItemControl.BackColor = Color.FromArgb(217, 217, 217);
            }
        }

        private void ButtonsVisibility()
        {
            btnRemove.Visible = true;
            btnComment.Visible = true;
            numQuantity.Visible = true;
            btnRemoveAll.Visible = false;
            addBtn.Visible = false;
        }

        private void ResetButtonVisibility()
        {
            btnRemove.Visible = false;
            btnComment.Visible = false;
            numQuantity.Visible = false;
            btnRemoveAll.Visible = true;
            addBtn.Visible = true;
        }

        private void dinnerBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Dinner;
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(sender as Button);
        }

        private void drinksBtn_Click(object sender, EventArgs e)
        {
            //selectedMenu = MenuItemType.Drinks;
            //ShowMenuItems(selectedMenu);
            //UpdateButtonAppearance(sender as Button);
        }

        private void UpdateButtonAppearance(Button activeButton)
        {
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(6, 167, 125);
                }
            }

            activeButton.BackColor = Color.FromArgb(1, 32, 24);
        }
    }

}


