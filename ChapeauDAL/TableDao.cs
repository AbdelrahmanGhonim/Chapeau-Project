using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class TableDao : BaseDao
    {

        public List<Table> GetAllTables()
        {
            string query = "SELECT Table_id, TableNumber, TableStatus FROM [Table]";
            return ReadTables(ExecuteSelectQuery(query));
        }
        public void UpdateTableStatus(Table table)
        {
            string updateQuery = "UPDATE [Table] SET TableStatus = @TableStatus WHERE Table_id = @Table_id";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TableStatus", table.Status.ToString()),
                new SqlParameter("@Table_id", table.TableId)
            };
            ExecuteEditQuery(updateQuery, sqlParameters);

        }

        public Table getTableById(int tableId)
        {
            string query = "SELECT table_id, TableNumber, TableStatus FROM [Table] WHERE table_id=@table_id";
            SqlParameter[] sqlParameter = new SqlParameter[1]
            {
                new SqlParameter("table_id", tableId),
            };
            return ReadTable(ExecuteSelectQueryWithParameters(query, sqlParameter));
        }




        private List<Table> ReadTables(DataTable dataTable)
        { 
            List<Table> tables = new List<Table>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Table table = new Table()
                {
                    TableId = (int)dataRow["table_id"],
                    TableNumber = (int)dataRow["TableNumber"],
                    Status = (TableStatus)Enum.Parse(typeof(TableStatus), (string)dataRow["TableStatus"])
                };
                tables.Add(table);
            }
            return tables;

        }


        private Table ReadTable(DataTable data)
        { 
        DataRow dataRow = data.Rows[0];
            Table table = new Table()
            {
                TableId = (int)dataRow["table_id"],
                TableNumber = (int)dataRow["TableNumber"],
                Status = (TableStatus)Enum.Parse(typeof(TableStatus), (string)dataRow["TableStatus"])
            };
            return table;
        }
    }

}
