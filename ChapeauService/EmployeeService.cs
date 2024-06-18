using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using ChapeauDAL;
using System.Drawing;
using NLog;


namespace ChapeauService
{
    public class EmployeeService
    {
        private EmployeeDao employeeDao;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public EmployeeService()
        {
            employeeDao = new EmployeeDao();
        }

        public Employee CheckLoginCredintial(string username, string password)
        {
            /*   try
               {
                   Employee employee = employeeDao.GetEmployeeByUsername(username);
                   if (employee != null)
                   {
                       bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, employee.Password);
                       if (isPasswordCorrect)
                       {
                           return employee;
                       }
                   }
                   return null;
               }catch (Exception ex) {
                   // Log the exception
                   Logger.Error(ex, $"Error during login for user {username}: {ex.Message}");
                   throw new ApplicationException("An error occurred while logging in. Please try again later.", ex);
               }

               return null;*/
            try
            {
                Employee employee = employeeDao.GetEmployeeByUsername(username);
                if (employee != null)
                {
                    Logger.Info($"Employee found with username: {username}");
                    bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, employee.Password);
                    if (isPasswordCorrect)
                    {
                        Logger.Info($"Password verification successful for username: {username}");
                        return employee;
                    }
                    else
                    {
                        Logger.Warn($"Incorrect password attempt for username: {username}");
                    }
                }
                else
                {
                    Logger.Warn($"No employee found with username: {username}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error during login for username {username}: {ex.Message}");
                throw new ApplicationException("An error occurred while checking login credentials.", ex);
            }
            return null;
        }

    }
}
