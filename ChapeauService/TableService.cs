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
        OrderDao orderDao;

        public TableService()
        {
            tableDao = new TableDao();
            orderDao = new OrderDao();
        }

        public List<Table> GetAllTables()
        {

            return tableDao.GetAllTables();
        }

        public void UpdateTableStatus(Table table)
        {
                tableDao.UpdateTableStatus(table);
        }

        public void CheckAndSetTableStatus(Table table)
        {
            bool allItemsServed = orderDao.GetOrderItems(table).All(item => item.OrderStatus == OrderStatus.Served);
            if (allItemsServed)
            {
                table.Status = TableStatus.Occupied;
            }
            UpdateTableStatus(table);
        }

        public void ReserveTable(Table table)
        {
            if (table.Status == TableStatus.Reserved)
            {
                throw new InvalidOperationException("The table is already reserved.");
            }

            // Check for unpaid order items before change the status
            CheckForUnpaidOrderItems(table);

            table.Status = TableStatus.Reserved;
            UpdateTableStatus(table);
        }

        public void FreeTable(Table table) {

            if (table.Status == TableStatus.Available)
            {
                throw new InvalidOperationException("The table is already available.");
            }

            // Check for unpaid order items before change the status
            CheckForUnpaidOrderItems(table);
            table.Status = TableStatus.Available;
            UpdateTableStatus(table);
        }

        public void OccupyTable(Table table)
        { 
             table.Status= TableStatus.Occupied;
            UpdateTableStatus(table);
        }
        public Table GetTableById(int id)
        {
         return tableDao.getTableById(id);
        }

        private void CheckForUnpaidOrderItems(Table table) //TODO: Ask Luca about how they check if if the order is payed or not 
        {
            List<OrderItem> unpaidItems = orderDao.GetOrderItems(table).ToList();
                                           
            if (unpaidItems.Any())
            {
                throw new InvalidOperationException("Order table is unpaid!");
            }
        }

    }

}
