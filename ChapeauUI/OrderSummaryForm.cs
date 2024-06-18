using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class OrderSummaryForm : Form
    {
        private List<OrderItem> orderItems;

        public OrderSummaryForm()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //add comments;
            if (result == DialogResult.Yes)
            {
                // Hide the current form
                this.Hide();

                // Show the login form
                Login loginForm = new Login();
                loginForm.Show();

                // Close the current form
                this.Close();
            }
        }

        private void OrderSummaryForm_Load(object sender, EventArgs e)
        {
            LoadOrderSummary();
        }

        private void LoadOrderSummary()
        {
            // Retrieve data from the OrderView
            // Assuming GetOrderSummary is a method that fetches order details from the database
            var orderSummary = GetOrderSummary();

            // Populate the dataGridViewOrderSummary
            dataGridViewOrderSummary.DataSource = orderSummary;

            // Calculate VAT and total amount
            decimal totalAmount = 0;
            decimal totalVAT = 0;
            foreach (var item in orderSummary)
            {
                decimal itemVAT = item.Price * item.Quantity * (item.IsAlcoholic ? 0.21m : 0.09m);
                totalVAT += itemVAT;
                totalAmount += item.Price * item.Quantity;
            }

            vatLabel.Text = $"VAT: {totalVAT:C2}";
            totalLabel.Text = $"Total: {totalAmount + totalVAT:C2}";
        }

        private List<OrderSummary> GetOrderSummary()
        {
            // Implementation to retrieve order summary from the database
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            // Create an instance of ReviewForm
            ReviewForm reviewForm = new ReviewForm();

            // Show the ReviewForm
            reviewForm.Show();

            this.Hide();
        }
    }
}

