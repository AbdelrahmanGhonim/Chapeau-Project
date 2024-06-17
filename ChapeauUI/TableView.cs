using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class TableView : Form
    {

      //  List<Table> allTables; // check if we using this list in moreThan one place
        private Employee LoggedInEployee;

        public TableView(Employee employee)
        {
            InitializeComponent();
          //  TableService tableService = new TableService();
           // allTables = tableService.getAllTables();
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
                if (table.Status == TableStatus.Ordered)
                {
                    ShowOrderItems(table, clickedButton.Location);
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
                // Assuming you have a method to create buttons dynamically based on the table data
                Button button = CreateButtonForTable(table, index);

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
                button.Click += TableButton_Click;//button.Click += (sender, e) => ShowOrderItems(table);


                // Add the button to the form's controls
                Controls.Add(button);

                // Create a label for food ready to serve notification
                Label foodReadyLabel = new Label
                {
                    Text = "", // Initially, the label is empty
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(button.Location.X, button.Location.Y + button.Height + 5) // Position the label below the button
                };
                foodReadyLabel.Tag = table;
                Controls.Add(foodReadyLabel);

                UpdateFoodReadyLabel(table, foodReadyLabel);




                index++;
            }
        }
        // Method to update the label text based on the order status
        private void UpdateFoodReadyLabel(Table table, Label foodReadyLabel)
        {
            OrderService orderService = new OrderService();
            List<OrderItem> items = orderService.getOrderItems(table);

            bool foodReady = items.Any(item => item.OrderStatus == OrderStatus.Prepared);

            if (foodReady)
            {
                foodReadyLabel.ForeColor = Color.Blue;
                foodReadyLabel.Text = "Food Ready!";
            }
            else
            {
                foodReadyLabel.Text = "";
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
            int buttonSize = 90; // Adjust button size as needed
            int margin = 25; // Adjust margin between buttons as needed
            int rows = 3; // Number of rows in the grid
            int columns = 4; // Number of columns in the grid
            int row = index / columns;
            int column = index % columns;
            int buttonX = column * (buttonSize + margin) + margin;
            int buttonY = row * (buttonSize + margin) + margin + 100;

            button.Location = new Point(buttonX, buttonY);

            button.Size = new Size(buttonSize, buttonSize);
            return button;
        }

        private void ShowOrderItems(Table table, Point buttonLocation)
        {

            OrderService orderService = new OrderService();
            List<OrderItem> items = orderService.getOrderItems(table); 
          

            Form orderForm = new Form()
            {
                Size = new Size(300, 400),
                StartPosition = FormStartPosition.Manual, // Set the form's start position to manual
                Location = new Point(buttonLocation.X + 100, buttonLocation.Y) // Adjust position based on button location
            };

            CheckedListBox checkedListBox = new CheckedListBox
            {
                Location = new Point(10, 10),
                Width = 250,
                Height = 300
            };

            // Dictionary to keep track of which item corresponds to which index
            Dictionary<int, OrderItem> itemIndexMapping = new Dictionary<int, OrderItem>();

            int index = 0;

                foreach (OrderItem item in items)
                {
                    if (item.OrderStatus == OrderStatus.Prepared)
                    {
                    //oliwia - has to me item.menuItem.Name 
                        //checkedListBox.Items.Add(item.ItemName);
                        itemIndexMapping[index] = item;
                        index++;
                    }
                }
                

            checkedListBox.ItemCheck += (sender, e) =>
            {
                if (e.NewValue == CheckState.Checked)
                {
                    // Update the status of the corresponding OrderItem to Served
                    OrderItem selectedItem = itemIndexMapping[e.Index];
                    selectedItem.OrderStatus = OrderStatus.Served;

                    // Here, you would also update the status in the database.
                    orderService.UpdateOrderItemStatus(selectedItem);
                }
            };

            orderForm.Controls.Add(checkedListBox);

            orderForm.FormClosed += (sender, e) =>
            {

                // Check if all items are served and update the table status if necessary
                bool allItemsServed = orderService.getOrderItems(table).All(item => item.OrderStatus == OrderStatus.Served);

                if (allItemsServed)
                {
                    table.Status = TableStatus.Occupied;
                    TableService tableService = new TableService();
                    tableService.UpdateTableStatus(table);
                }
                RefreshTableView();
            };

            orderForm.ShowDialog();
         
        }


        private void RefreshTableView()
        { 
            Controls.Clear();
            InitializeComponent();
            TablesViewDesign();
        }

        private void DisplayEmployeeName()
        {
            usernamelbl.Text = LoggedInEployee.FirstName; 

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
