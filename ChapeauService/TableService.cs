using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class TableService
    {
        private TableDao tableDao;

        public TableService()
        {
            tableDao = new TableDao();
        }

        public List<Table> GetAllTables()
        {
            return tableDao.GetAllTables();
        }

        public void UpdateTableStatus(Table table)
        {
            tableDao.UpdateTableStatus(table);
        }
        public Table GetTableById(int id)
        {
         return tableDao.getTableById(id);
        }

    }

}
