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
        private List<OrderItem> orderedItems;
        private OrderService orderService;
        private Table selectedTable;
        private Employee loggedEmployee;
        private MenuItemsService menuItemsService;

        public OrderList(Table table, Employee employee)
        {
            InitializeComponent();
            selectedMenu = MenuItemType.Lunch;            
            
            this.selectedTable = table;
            this.loggedEmployee = employee;

            orderedItems = new List<OrderItem>();
            menuItemsService = new MenuItemsService();
            orderService = new OrderService();

            InitializeMenu();
            InitializeRoleLabel();
        }
        private void InitializeRoleLabel()
        {
            lblRole.Text = $"{loggedEmployee.Role}: {loggedEmployee.FirstName}";
        }
        private void InitializeMenu()
        {
            ShowMenuItems(selectedMenu);

            listViewOrder.SelectedIndexChanged += listViewOrder_SelectedIndexChanged;
            numQuantity.ValueChanged += numQuantity_ValueChanged;

            UpdateButtonVisibility();
        }

        //menu
        private void ShowMenuItems(MenuItemType menuItemType)
        {
            try
            {
                 menuItemsService = new MenuItemsService();
                List<MenuItem> menuItemsList = menuItemsService.GetMenuItemsByType(menuItemType);

                if (menuItemsList.Count == 0)
                {
                    MessageBox.Show("No menu items found.");
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

            UpdateButtonVisibility();
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
                var menuItemControl = new MenuItemControl();
                menuItemControl.SetMenuItem(menuItem.ItemId, menuItem.Name, menuItem.Price);

                if (menuItem.Stock <= 0)
                {
                    menuItemControl.Enabled = false;
                    menuItemControl.BackColor = Color.Gray;
                }
                else
                {
                    menuItemControl.MenuItemClicked += MenuItemControl_MenuItemClicked;
                }

                flowLayoutPanelMenu.Controls.Add(menuItemControl);
            }
        }
        //order list
        private void AddMenuItemToListView(OrderItem orderItem)
        {
            ListViewItem li = new ListViewItem($"{orderItem.Quantity}x");
            li.SubItems.Add($"{orderItem.MenuItem.Name}");
            li.SubItems.Add($"{orderItem.Comments}");
            li.Tag = orderItem;
            listViewOrder.Items.Add(li);
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
        //listView index
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
        //adding order
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsStockAvailable())
            {
                MessageBox.Show("Not enough available stock.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to add this order?", "Confirm Add Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var newOrder = new Order(selectedTable, loggedEmployee)
                    {
                        OrderedItems = orderedItems
                    };

                    orderService.AddOrder(newOrder);

                    MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TableView tableView = new TableView(loggedEmployee);
                    OpenUI(tableView);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsStockAvailable()
        {
            foreach (var orderItem in orderedItems)
            {
                int currentStock = menuItemsService.GetCurrentStock(orderItem.MenuItem.ItemId);
                if (currentStock < orderItem.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
        //buttons
        private void btnAddComment_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxComment.Text))
            {
                MessageBox.Show("Comment cannot be empty.", "Empty Comment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlComment.Visible = false;
            EnableControls(true);

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
                    EnableControls(false);
                    txtBoxComment.Text = currentComment;
                }
                else
                {
                    MessageBox.Show("The selected item does not have a comment.");
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
                UpdateButtonVisibility();
            }
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            orderedItems.Clear();

            ResetButtonVisibility();
            UpdateButtonVisibility();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlComment.Visible = false;
            EnableControls(true);
        }
        private void lunchBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Lunch;
            ShowMenuItems(selectedMenu);
        }
        private void dinnerBtn_Click_1(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Dinner;
            ShowMenuItems(selectedMenu);
        }
        private void drinksBtn_Click(object sender, EventArgs e)
        {
            selectedMenu = MenuItemType.Drinks;
            ShowMenuItems(selectedMenu);
        }
        private void tableViewBtn_Click(object sender, EventArgs e)
        {
            TableView tableView = new TableView(loggedEmployee);
            OpenUI(tableView);
        }
        private void logOutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenUI(new Login());
                Close();
            }
        }
        //buttons etc 
        private void ButtonsVisibility()
        {
            SetButtonVisibility(true);
        }

        private void ResetButtonVisibility()
        {
            SetButtonVisibility(false);
        }

        private void SetButtonVisibility(bool isVisible)
        {
            btnRemove.Visible = isVisible;
            btnComment.Visible = isVisible;
            numQuantity.Visible = isVisible;
        }

        private void UpdateButtonVisibility()
        {
            bool hasItems = listViewOrder.Items.Count > 0;
            btnAdd.Visible = hasItems;
            btnRemoveAll.Visible = hasItems;
        }
        private void EnableControls(bool enable)
        {
            foreach (Control control in Controls)
            {
                if (control != pnlComment)
                {
                    control.Enabled = enable;
                }
            }
        }
        private void OpenUI(Form form)
        {
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}


