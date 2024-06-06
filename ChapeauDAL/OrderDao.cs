using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;


namespace ChapeauDAL
{
    public class OrderDao:BaseDao
    {

        MenuItemsDao menuItemsDAO;

        public OrderDao() : base()
        {
            menuItemsDAO = new MenuItemsDao();
        }

        public void AddNewOrder()
        {

        }
    }
}
