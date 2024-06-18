using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;


namespace ChapeauDAL
{
    public class EmployeeDao : BaseDao
    {
        //        Waiter, Bartender, Chef, Manager
        public Employee GetEmployeeByUsername(string username) 
        {
            try
            {
                string query = "SELECT employee_id,username,firstname, lastname, EmployeeRole, password FROM employee WHERE username=@username";

                SqlParameter[] sqlParameters = new SqlParameter[1]
                {
                new SqlParameter("@username",username)
                };
                DataTable dataTable = ExecuteSelectQueryWithParameters(query, sqlParameters);

                if (dataTable.Rows.Count == 0)//nothing found
                {
                    return null;
                }
                else
                {
                    return ReadEmployee(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching employee data.", ex);
            }
        }



        private Employee ReadEmployee(DataTable data)
        {
            DataRow dataRow = data.Rows[0];
            Employee employee = new Employee()
            {

                EmployeeId = (int)dataRow["employee_id"],
                Username = (string)dataRow["username"],
                Password = (string)dataRow["password"],
                FirstName = (string)dataRow["firstname"],
                LastName = (string)dataRow["lastname"],
                Role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), (string)dataRow["EmployeeRole"])
            };
            return employee;
        }
       


    }
}

