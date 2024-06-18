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
    public partial class ReviewForm : Form
    {

        private int numberOfPeople;

        public ReviewForm()
        {
            InitializeComponent();
            paymentButton.Enabled = false;
            this.numberOfPeople = numberOfPeople;
        }

        private void TipTextbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePaymentButtonState();
        }

        private void UpdatePaymentButtonState()
        {
            bool isTipTextboxValid = decimal.TryParse(tipTextbox.Text, out decimal tipAmount) && tipAmount > 0;

            paymentButton.Enabled = tip0Checkbox.Checked || tip2Checkbox.Checked || tip5Checkbox.Checked || tip10Checkbox.Checked || isTipTextboxValid;
        }

        private void sendFeedbackButton_Click(object sender, EventArgs e)
        {
            // Get the feedback text
            string feedback = feedbackTextbox.Text;

            // Send feedback to database
            SendFeedbackToDatabase(feedback);

            // Clear the textbox
            feedbackTextbox.Text = string.Empty;
        }

        private void SendFeedbackToDatabase(string feedback)
        {
            // Your database connection string
            string connectionString = "ChapeauDatabase";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Feedback (Comment) VALUES (@feedback)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@feedback", feedback);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentMethod paymentMethodForm = new PaymentMethod();
            paymentMethodForm.Show();
        }
    }
}
