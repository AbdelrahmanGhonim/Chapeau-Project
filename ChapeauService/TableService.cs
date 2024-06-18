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
        private readonly ActivityLogger logger = new ActivityLogger();


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


        public void ReserveTable(Table table)
        {
            if (table.Status == TableStatus.Reserved)
            {
                throw new InvalidOperationException("The table is already reserved.");
            }

            table.Status = TableStatus.Reserved;
            logger.Log($"Table {table.TableNumber} set to Reserved.");

            UpdateTableStatus(table);
        }

        public void FreeTable(Table table) {

            if (table.Status == TableStatus.Available)
            {
                throw new InvalidOperationException("The table is already available.");
            }

            table.Status = TableStatus.Available;
            logger.Log($"Table {table.TableNumber} set to Available.");
            UpdateTableStatus(table);
        }

        public void OccupyTable(Table table)
        { 
            if(table.Status==TableStatus.Occupied)
            {
                throw new InvalidOperationException("The table is already Occupied.");
            }
            table.Status= TableStatus.Occupied;
            logger.Log($"Table {table.TableNumber} set to Occupied.");

            UpdateTableStatus(table);
        }

        //TODO: waiting for Luca to finish this part 
        private bool CheckForUnpaidOrderItems(Table table)
        {

            return true;
        }

    }

}
