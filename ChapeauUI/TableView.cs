 using ChapeauModel;
using ChapeauService;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;



namespace ChapeauUI
{
    public partial class TableView : Form
    {

        private Employee LoggedInEployee;



        public TableView(Employee employee)
        {
            InitializeComponent();
       
            LoggedInEployee = employee;
            DisplayEmployeeName();
            TablesViewDesign();
        }

 
        private void TableButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = (Button)sender;
                Table table = (Table)clickedButton.Tag;
                OrderService orderService = new OrderService();
                List<OrderItem> orderItems  = orderService.GetOrderItems(table);
                List<OrderItem> unservedItems = orderItems.Where(item => item.OrderStatus != OrderStatus.Served).ToList();//TODO: check that or should I do it in teh Dao 
                List<OrderItem> preparedItems = orderItems.Where(item => item.OrderStatus == OrderStatus.Prepared).ToList();//TODO: discuss in the meeting

                if (table.Status == TableStatus.Ordered)
                {
                    if (preparedItems.Any()) //check if there are any preparedITems
                    {
                        ShowReadyOrderItems(table, clickedButton.Location, preparedItems);
                    }
                    else
                    {
                        //a method that shows a list of items and with Time
                        ShowOrderItems(table, clickedButton.Location, unservedItems);
                    }
                }
                else
                {
                    TableOptionUI newForm = new TableOptionUI(table, LoggedInEployee);
                    OpenUI(newForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private Color GetColorForTableStatus(TableStatus tableStatus)
        {

            switch (tableStatus)
            {
                case TableStatus.Reserved:
                    return Color.FromArgb(255, 0, 0); ;
                case TableStatus.Occupied:
                    return Color.Yellow;
                case TableStatus.Ordered:
                    return Color.Silver;
                default:
                    return Color.LightGreen;
            }
        }

        private void TablesViewDesign()
        {
            TableService tableService=new TableService();
            List<Table> allTables= tableService.GetAllTables();
            int index = 0;
            foreach (Table table in allTables)
            {
                Button button = CreateButtonForTable(table, index);
                ConfigureTableButton(button, table, index);

                // Add the button to the form's controls
                Controls.Add(button);

                Label foodReadyLabel = ConfigureLabel(button, table);
                Controls.Add(foodReadyLabel);

                UpdateFoodReadyLabel(table, foodReadyLabel);

                index++;
            }
        }

        private void ConfigureTableButton(Button button, Table table, int index)
        {
            // Set size, font, and circular shape
            button.Size = new Size(90, 90); // Adjust size as needed
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = GetColorForTableStatus(table.Status);

            // Assign the table to the Tag property of the button
            button.Tag = table;

            // Make the button circular
            GraphicsPath buttonPath = new GraphicsPath();
            buttonPath.AddEllipse(0, 0, button.Width, button.Height);
            button.Region = new Region(buttonPath);

            // Attach the TableButton_Click event handler to the Click event of the button
            button.Click += TableButton_Click;
        }
        private Label ConfigureLabel(Button button, Table table)
        {
            return new Label
            {
                Text = "", // Initially, the label is empty
                ForeColor = Color.Red,
                AutoSize = true,
                Location = new Point(button.Location.X, button.Location.Y + button.Height + 5), // Position the label below the button
                Tag = table
            };
        }


        // Method to update the label text based on the order status
        private void UpdateFoodReadyLabel(Table table, Label foodReadyLabel)
        {
            OrderService orderService = new OrderService();
            List<OrderItem> items = orderService.GetOrderItems(table);

            bool foodReady = items.Any(item => item.OrderStatus == OrderStatus.Prepared);

            if (table.Status == TableStatus.Ordered)
            {
                if (foodReady)
                {
                    foodReadyLabel.ForeColor = Color.Blue;
                    foodReadyLabel.Text = "Food Ready!";
                }
                else
                {
                    foodReadyLabel.ForeColor = Color.Green;
                    foodReadyLabel.Text = "Running Food";
                }
            }
        }


        private void OpenUI(Form popUpForm)
        {
            Form activeForm = ActiveForm;
            activeForm.Hide();

            popUpForm.ShowDialog();

            //why I close it when I am hide it?
            activeForm.Close();
        }


        private Button CreateButtonForTable(Table table, int index)
        {
            Button button = new Button();

            // Set button text
            button.Text = "Table " + table.TableNumber; // Assuming TableId is a property of the Table class

            // Calculate button size and position for a grid layout
            int buttonSize = 90;
            int margin = 25; 
            int rows = 3; 
            int columns = 4; 
            int row = index / columns;
            int column = index % columns;
            int buttonX = column * (buttonSize + margin) + margin;
            int buttonY = row * (buttonSize + margin) + margin + 100;

            button.Location = new Point(buttonX, buttonY);

            button.Size = new Size(buttonSize, buttonSize);
            return button;
        }

        private void ShowReadyOrderItems(Table table, Point buttonLocation,List<OrderItem> preparedItems)
        { 

            Form orderForm = CreateOrderForm(buttonLocation);
            CheckedListBox checkedListBox = CreateCheckedListBox(preparedItems, out Dictionary<int, OrderItem> itemIndexMapping);

            checkedListBox.ItemCheck += (sender, e) => UpdateOrderItemStatus(e, itemIndexMapping, new OrderService());

            orderForm.Controls.Add(checkedListBox);

            orderForm.FormClosed += (sender, e) =>
            {
                HandleFormClosed(table);
                RefreshTableView();
            };

            orderForm.ShowDialog();
        }

        private Form CreateOrderForm(Point buttonLocation)
        {
            return new Form()
            {
                Size = new Size(300, 400),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(buttonLocation.X + 100, buttonLocation.Y)
            };
        }
        private CheckedListBox CreateCheckedListBox(List<OrderItem> preparedItems, out Dictionary<int, OrderItem> itemIndexMapping)
        {
            CheckedListBox checkedListBox = new CheckedListBox
            {
                Location = new Point(10, 10),
                Width = 250,
                Height = 300
            };

            itemIndexMapping = new Dictionary<int, OrderItem>();
            int index = 0;

            foreach (OrderItem item in preparedItems)
            {
                    checkedListBox.Items.Add(item.MenuItem.Name);
                    itemIndexMapping[index] = item;
                    index++;
            }

            return checkedListBox;
        }

        private void UpdateOrderItemStatus(ItemCheckEventArgs e, Dictionary<int, OrderItem> itemIndexMapping, OrderService orderService)
        {
            if (e.NewValue == CheckState.Checked)
            {
                OrderItem selectedItem = itemIndexMapping[e.Index];
                selectedItem.OrderStatus = OrderStatus.Served;

                // Update the status in the database
                orderService.UpdateOrderItemStatus(selectedItem);
            }
        }
        private void HandleFormClosed(Table table)
        {
                TableService tableService = new TableService();
                tableService.CheckAndSetTableStatus(table);
        }



        private void RefreshTableView()
        {
            Controls.Clear();
            InitializeComponent();
            DisplayEmployeeName();
            TablesViewDesign();
        }

        private void DisplayEmployeeName()
        {
            usernamelbl.Text =LoggedInEployee.Role.ToString()+": " + LoggedInEployee.FirstName; 

        }


        private void ShowOrderItems(Table table, Point buttonLocation, List<OrderItem> items)
        {
            Form orderForm = CreateOrderForm(buttonLocation);
          

            ListView listView = new ListView
            {
                Location = new Point(10, 10),
                Width = 250,
                Height = 300,
                View = View.Details
            };
            listView.Columns.Add("Item", 150);
            listView.Columns.Add("Time Left", 100);

            foreach (OrderItem item in items)
            {
                ListViewItem listViewItem = new ListViewItem(item.MenuItem.Name);
                listViewItem.SubItems.Add(GetCountdownString(item));
                listViewItem.Tag = item;
                listView.Items.Add(listViewItem);

                SetupTimer(listViewItem, item);
            }

            orderForm.Controls.Add(listView);
            orderForm.ShowDialog();

            OrderService orderService = new OrderService();
            orderForm.FormClosed += (sender, e) =>
            {
                HandleFormClosed(table);


                RefreshTableView();
            };
        }


        private void SetupTimer(ListViewItem listViewItem, OrderItem orderItem)
        {
            Timer timer = new Timer(); 
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, e) => UpdateCountdown(listViewItem, orderItem);
            timer.Start();
        }

        private void UpdateCountdown(ListViewItem listViewItem, OrderItem orderItem)
        {
            DateTime now = DateTime.Now;
            DateTime targetTime = orderItem.Order.OrderTime.Add(orderItem.MenuItem.PreparationTime);

            TimeSpan timeLeft = targetTime - now;

            if (timeLeft.TotalSeconds <= 0)
            {
                listViewItem.SubItems[1].Text = "-" + timeLeft.Negate().ToString(@"hh\:mm\:ss"); // Display negative countdown
                listViewItem.ForeColor = Color.Red; // Set text color to red when time is up
              

            }
            else
            {
                listViewItem.SubItems[1].Text = timeLeft.ToString(@"hh\:mm\:ss");
                listViewItem.ForeColor = SystemColors.ControlText; // Reset text color

            }
        }

        private string GetCountdownString(OrderItem orderItem)
        {
            DateTime now = DateTime.Now;
            DateTime targetTime = orderItem.Order.OrderTime.Add(orderItem.MenuItem.PreparationTime);

            TimeSpan timeLeft = targetTime - now;

            if (timeLeft.TotalSeconds <= 0)
            {
                return "-" + timeLeft.Negate().ToString(@"hh\:mm\:ss"); // Return negative countdown string
            }

            return timeLeft.ToString(@"hh\:mm\:ss");
        }



        private void logoutbtn_Click(object sender, EventArgs e) //TODO:check it with the Teacher! About the ActivityLogger !!
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Show the login form
                Login loginForm = new Login();
               OpenUI(loginForm);
                this.Close();
            }
        }
    }
}
