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
using NLog;


namespace ChapeauUI
{
    public partial class Login : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
            try
            {
                EmployeeService employeeService = new EmployeeService();

                Employee loggedinElpoyee = employeeService.CheckLoginCredintial(usernameTxt.Text, passwordTxt.Text);

                if (loggedinElpoyee != null)
                {
                    // go to the View bassed on the employeeRole
                    getUIBassedOnEmployeeRole(loggedinElpoyee);

                }
                else
                {
                    invalidcredentiallbl.Text = "Invalid Username and Password";
                }
            }
            catch (Exception ex)
            {
                invalidcredentiallbl.Text = "An unexpected error occurred. Please try again later.";
                Logger.Error(ex, "Unexpected error during login: " + ex.Message);
            }
        }


        private void FilledUsernameAndPassword(Object sender, EventArgs e)
        {
            bool isUsernameFilled = !string.IsNullOrWhiteSpace(usernameTxt.Text);
            bool isPasswordFilled = !string.IsNullOrWhiteSpace(passwordTxt.Text);
            loginbtn.Enabled = isUsernameFilled && isPasswordFilled;
        }

        private void getUIBassedOnEmployeeRole(Employee employee)// change the name to something else because get seems to return something
        {
            switch (employee.Role)
            {
                case EmployeeRole.Waiter:
                    OpenUI(new TableView(employee));
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

        private void OpenUI(Form newForm)
        {

            Form activeForm = ActiveForm;
            activeForm.Hide();

            newForm.ShowDialog();

            activeForm.Close();
        }

       
    }
}
