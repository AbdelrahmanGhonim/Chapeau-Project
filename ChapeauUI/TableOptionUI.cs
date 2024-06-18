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
    public partial class TableOptionUI : Form //don't forget todo error handler 
    {
        private Table table;
        private Employee loggedInEmployee;
        private TableService tableService;
        public TableOptionUI(Table table, Employee employee) //I should Pass the Employee 
        {
            InitializeComponent();
            this.table = table;
            this.loggedInEmployee = employee;
            this.tableService = new TableService(); // Initialize the TableService
            tableNumberlbl.Text= "Table: " +  table.TableNumber.ToString();

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            TableView tableView = new TableView(loggedInEmployee);
            OpenUI(tableView);


        }
        private void OpenUI(Form popUpForm) //check if there is a way instead of writing the same method in different UI
        {
            Form activeForm = ActiveForm;
            activeForm.Hide();

            popUpForm.ShowDialog();

            activeForm.Close();
        }

        private void reserveTablebtn_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the table has a bill or not
                tableService.ReserveTable(table);
                errorhandlerlbl.Text = "Table reserved successfully.";
                errorhandlerlbl.ForeColor = Color.Yellow;                                                      
            }
            catch (InvalidOperationException ex)
            {
                errorhandlerlbl.Text = ex.Message;
                errorhandlerlbl.ForeColor = Color.Red;
            }

        }

        private void FreeTablebtn_Click(object sender, EventArgs e)
        {
            try
            {
                //check if the table has a bill or not
                tableService.FreeTable(table);
                errorhandlerlbl.Text = "Table is now available.";
                errorhandlerlbl.ForeColor = Color.Yellow; 
                                                       
            }
            catch (InvalidOperationException ex)
            {
                errorhandlerlbl.Text = ex.Message;
                errorhandlerlbl.ForeColor = Color.Red; 
            }
        }

        private void placeOrderbtn_Click(object sender, EventArgs e)
        {
            OrderList orderList = new OrderList(table, loggedInEmployee);
            OpenUI(orderList);
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            //OpenUI to the Payment Details

        }
  
    }
}
