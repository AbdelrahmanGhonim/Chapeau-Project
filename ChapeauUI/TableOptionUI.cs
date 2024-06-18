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
    public partial class TableOptionUI : Form  
    {
        private Table table;
        private Employee loggedInEmployee;
        private TableService tableService;
        public TableOptionUI(Table table, Employee employee) 
        {
            InitializeComponent();
            this.table = table;
            this.loggedInEmployee = employee;
            this.tableService = new TableService(); 
            tableNumberlbl.Text = "Table: " + table.TableNumber.ToString();

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            TableView tableView = new TableView(loggedInEmployee);
            OpenUI(tableView);
        }

        private void OpenUI(Form popUpForm)
        {
            Form activeForm = ActiveForm;
            activeForm.Hide();

            popUpForm.ShowDialog();

            activeForm.Close();
        }

        private void reserveTablebtn_Click(object sender, EventArgs e)
        {
            //I should add event listener to the button to check if there is a bill for this table or not before change the status
            try
            {
                tableService.ReserveTable(table);
                infolbl.Text = "Table reserved successfully.";
                infolbl.ForeColor = Color.Yellow;
            }
            catch (InvalidOperationException ex)
            {
                infolbl.Text = ex.Message;
                infolbl.ForeColor = Color.Red;
            }

        }

        private void FreeTablebtn_Click(object sender, EventArgs e)
        {
            //I should add event listener to the button to check if there is a bill for this table or not before change the status
            try
            {
                tableService.FreeTable(table);
                infolbl.Text = "Table is now available.";
                infolbl.ForeColor = Color.Yellow;

            }
            catch (InvalidOperationException ex)
            {
                infolbl.Text = ex.Message;
                infolbl.ForeColor = Color.Red;
            }
        }
        private void occupybtn_Click(object sender, EventArgs e)
        {
            try 
            { 
                tableService.OccupyTable(table);
                infolbl.Text = "Table is now Occupied.";
                infolbl.ForeColor = Color.Yellow;
            }
            catch (InvalidOperationException ex)
            {
                infolbl.Text = ex.Message;
                infolbl.ForeColor = Color.Red;
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
