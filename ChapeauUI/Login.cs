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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            loginbtn.Enabled = false;

            // Attach event handlers to the text changed events
            usernameTxt.TextChanged += FilledUsernameAndPassword;
            passwordTxt.TextChanged += FilledUsernameAndPassword;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();

            Employee loggedinElpoyee = employeeService.CheckLoginCredintial(usernameTxt.Text, passwordTxt.Text);

            if(loggedinElpoyee != null )
            {
                // go to the View bassed on the employeeRole
                getUIBassedOnEmployeeRole(loggedinElpoyee.Role);

            }
            else
            {
                //TODO: display it inside the label better than messagebox
                MessageBox.Show("Invalid Username or Password");
            }

        }

           
        private void FilledUsernameAndPassword(Object sender, EventArgs e)
        {
            bool isUsernameFilled = !string.IsNullOrWhiteSpace(usernameTxt.Text);
            bool isPasswordFilled = !string.IsNullOrWhiteSpace(passwordTxt.Text);
            loginbtn.Enabled = isUsernameFilled && isPasswordFilled;
        }

        private void getUIBassedOnEmployeeRole(EmployeeRole role)
        { 
        switch (role)
            {
                case EmployeeRole.Waiter:
                    //go to tableview
                    break;
                case EmployeeRole.Chef:
                    //go to kitchenview
                    break;
                case EmployeeRole.Bartender:
                    //go to barview
                    break;
                case EmployeeRole.Manager:
                    //go to managerview
                    break;
            }
        }
    }
}
