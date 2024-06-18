using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using NLog;


namespace ChapeauDAL
{
    public class EmployeeDao : BaseDao
    {
        //        Waiter, Bartender, Chef, Manager
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public Employee GetEmployeeByUsername(string username) //check the name if it is lower or upper case, it should be case sensitive
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
                // Log the exception
                Logger.Error(ex, $"Error fetching employee by username {username}: {ex.Message}");

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
       

   /*     public bool VerifyLogin(string username, string password)
        {
            string query = "SELECT Password FROM employee WHERE username = @username";
            SqlParameter parameter = new SqlParameter("@username", username);
            string hashedPasswordFromDB = ExecuteSelectQueryWithParameters(query, parameter).Rows[0]["PasswordHash"].ToString();

            return BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDB);
        }
       */
    }
}

