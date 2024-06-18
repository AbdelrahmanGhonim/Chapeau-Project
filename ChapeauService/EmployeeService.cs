using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using ChapeauDAL;
using System.Drawing;


namespace ChapeauService
{
    public class EmployeeService
    {
        private EmployeeDao employeeDao;
        private readonly ActivityLogger logger = new ActivityLogger();

        public EmployeeService()
        {
            employeeDao = new EmployeeDao();
        }

        public Employee CheckLoginCredintial(string username, string password)
        {
            try
            {
                Employee employee = employeeDao.GetEmployeeByUsername(username);
                if (employee != null)
                {
                    bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, employee.Password);
                    if (isPasswordCorrect)
                    {
                        logger.Log($"Password verification successful for username: {username}");
                        return employee;
                    }
                }
                else
                {
                    logger.Log($"No employee found with username: {username}", "WARN");
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error during login for username {username}: {ex.Message}", "ERROR");
                throw new ApplicationException("An error occurred while checking login credentials.", ex);
            }
            return null;
        }

    }
}
