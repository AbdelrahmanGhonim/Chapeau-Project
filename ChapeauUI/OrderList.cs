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
using System.Globalization;

namespace ChapeauUI {

    public partial class OrderList : Form
    {
        private MenuItemType selectedMenu;
        private MenuItemControl selectedMenuItemControl;
        private List<OrderItem> orderedItems;
        private OrderService orderService;
        private Table selectedTable;
        private Employee loggedEmployee;

        public OrderList(Table table, Employee employee)
        {
            InitializeComponent();
            this.selectedMenu = MenuItemType.Lunch;
            this.orderedItems = new List<OrderItem>();
            this.orderService = new OrderService();
            this.selectedTable = table;
            this.loggedEmployee = employee;

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

        private void MenuItemControl_MenuItemClicked(object sender, MenuItemControl menuItemControl)
        {
            if (selectedMenuItemControl != null)
            {
                selectedMenuItemControl.BackColor = Color.FromArgb(217, 217, 217);
            }

            selectedMenuItemControl = menuItemControl;
            selectedMenuItemControl.BackColor = Color.DarkGray;

            MenuItemsService menuItemsService = new MenuItemsService();
            MenuItem menuItem = menuItemsService.GetMenuItemById(menuItemControl.MenuItemId);

            OrderItem existingItem = orderedItems.FirstOrDefault(item => item.MenuItem.ItemId == menuItem.ItemId && string.IsNullOrEmpty(item.Comments));
            if (existingItem != null)
            {
                existingItem.Quantity++;
                UpdateListViewItem(existingItem);
            }
            else
            {
                OrderItem newOrderItem = new OrderItem(menuItem);
                orderedItems.Add(newOrderItem);
                AddMenuItemToListView(newOrderItem);
            }

            UpdateAddButtonVisibility();
        }

        private void UpdateListViewItem(OrderItem orderItem)
        {
            foreach (ListViewItem item in listViewOrder.Items)
            {
                if (item.Tag == orderItem)
                {
                    item.SubItems[0].Text = $"{orderItem.Quantity}x";
                    break;
                }
            }
        }

        private void AddMenuItemToListView(OrderItem orderItem)
        {
            ListViewItem li = new ListViewItem($"{orderItem.Quantity}x");
            li.SubItems.Add($"{orderItem.MenuItem.Name}");
            li.SubItems.Add($"{orderItem.Comments}");
            li.Tag = orderItem;
            listViewOrder.Items.Add(li);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Order newOrder = new Order(selectedTable, loggedEmployee);
                newOrder.OrderedItems = orderedItems;

                orderService.AddOrder(newOrder);

                MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                ButtonsVisibility();
                ListViewItem selectedItem = listViewOrder.SelectedItems[0];

                int quantity = int.Parse(selectedItem.SubItems[0].Text.Replace("x", ""));
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
                    orderedItems.Remove(orderItem);
                }
                else
                {
                    orderItem.Quantity = (int)numQuantity.Value;
                    selectedItem.SubItems[0].Text = $"{orderItem.Quantity}x";
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
                orderItem.Comments = txtBoxComment.Text;
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

        private void lunchBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Lunch;
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(sender as Button);
        }
        private void dinnerBtn_Click_1(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Dinner;
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(sender as Button);
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
                OrderItem orderItem = (OrderItem)selectedItem.Tag;

                listViewOrder.Items.Remove(selectedItem);
                orderedItems.Remove(orderItem);
                listViewOrder.SelectedItems.Clear();

                ResetButtonVisibility();
            }
        }

        private void UpdateAddButtonVisibility()
        {
            addBtn.Visible = listViewOrder.Items.Count > 0;
            btnRemoveAll.Visible = listViewOrder.Items.Count > 0;
        }

        private void ButtonsVisibility()
        {
            btnRemove.Visible = true;
            btnComment.Visible = true;
            numQuantity.Visible = true;
            btnRemoveAll.Visible = false;
        }

        private void ResetButtonVisibility()
        {
            btnRemove.Visible = false;
            btnComment.Visible = false;
            numQuantity.Visible = false;
            btnRemoveAll.Visible = true;
        }

        private void UpdateButtonAppearance(Button button)
        {
            lunchBtn.BackColor = Color.FromArgb(192, 192, 192);

            button.BackColor = Color.DarkGray;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            orderedItems.Clear();
            ResetButtonVisibility();
        }

        private void drinksBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Drinks;
            ShowMenuItems(selectedMenu);
            UpdateButtonAppearance(sender as Button);
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                OpenUI(loginForm);
                this.Close();
            }
        }
        private void OpenUI(Form popUpForm)
        {
            Form activeForm = ActiveForm;
            activeForm.Hide();

            popUpForm.ShowDialog();

            activeForm.Close();
        }
    }


}


