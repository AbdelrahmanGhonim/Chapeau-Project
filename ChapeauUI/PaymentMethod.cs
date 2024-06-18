using ChapeauModel;
using ChapeauService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class PaymentMethod : Form
    {
        private int tableId;
        private TableService tableService;
        private PaymentService paymentService;
        

        public PaymentMethod()
        {
            InitializeComponent();
            this.tableId = tableId;
            this.tableService = new TableService();
            this.paymentService = new PaymentService();
            numericUpDown.Visible = false;
        }


        private void payButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePayment())
            {
                MessageBox.Show("Payment method or amount that needs to be paid is not valid.");
                return;
            }

            decimal amountToPay = decimal.Parse(amountTextbox.Text);
            string paymentMethod = GetSelectedPaymentMethod();
            int numberOfSplits = (int)numericUpDown.Value;

            if (yesCheckbox.Checked)
            {
                numericUpDown.Visible = true;
                for (int i = 0; i < numberOfSplits; i++)
                {
                    ProcessPayment(paymentMethod, amountToPay);
                    MessageBox.Show($"Payment number {i + 1} done");
                }
            }
            else
            {
                ProcessPayment(paymentMethod, amountToPay);
                MessageBox.Show("Payment is completed");
            }
            SetTableFree(tableId);
        }

        private bool ValidatePayment()
        {
            if (!yesCheckbox.Checked || !noCheckbox.Checked) return false;
            if (!cashCheckBox.Checked || !debitCheckBox.Checked || !visaCheckBox.Checked) return false;
            if (string.IsNullOrEmpty(amountTextbox.Text)) return false;
            return true;
        }

        private string GetSelectedPaymentMethod()
        {
            if (cashCheckBox.Checked) return "Cash";
            else if (debitCheckBox.Checked) return "Debit";
            else return "Visa";
        }

        private void ProcessPayment(string paymentMethod, decimal amount)
        {
            paymentService.ProcessPayment(tableId, paymentMethod, amount);
        }

        private void SetTableFree(int tableId)
        {
            TableService.SetTableFree(tableId);
        }
    }
}
