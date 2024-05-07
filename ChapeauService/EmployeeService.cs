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
        public EmployeeService()
        {
            employeeDao = new EmployeeDao();
        }

        public Employee CheckLoginCredintial(string username, string password)
        { 
            Employee employee = employeeDao.GetEmployeeByUsername(username);
            if(employee != null)
            {
                bool isPasswordCorrect=BCrypt.Net.BCrypt.Verify(password, employee.Password);
                if(isPasswordCorrect)
                {
                    return employee;
                }
            }
            return null;

        }

    }
}
