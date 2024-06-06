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
        public TableOptionUI(Table table, Employee employee) //I should Pass the Employee 
        {
            InitializeComponent();
            this.table = table;
            this.loggedInEmployee = employee;
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

            //why I close it when I am hide it?
            activeForm.Close();
        }

        private void reserveTablebtn_Click(object sender, EventArgs e)
        {
            //check the Table Status before you setting the table, for example if the table is already Reserved to display a message or something
            ChangeTableStatus(TableStatus.Reserved);
            //display a message or change the button color

        }

        private void ChangeTableStatus(TableStatus tableStatus)
        {
            table.Status = tableStatus;
            TableService tableService = new TableService();
            tableService.UpdateTableStatus(table);
        }

        private void FreeTablebtn_Click(object sender, EventArgs e)
        {
            ChangeTableStatus(TableStatus.Available);
            //display a message or change the button color
        }

        private void placeOrderbtn_Click(object sender, EventArgs e)
        {
            //OpenUI to the Order View
        }

        private void paybtn_Click(object sender, EventArgs e)
        {
            //OpenUI to the Payment Details

        }
    }
}
