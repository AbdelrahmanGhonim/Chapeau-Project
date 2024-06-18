using ChapeauDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class PaymentService
    {
        private PaymentDAO paymentDAO;

        public void ProcessPayment(int tableId, string paymentMethod, decimal amount)
        {
            decimal vat = CalculateVAT(amount);
            int tip = GetTipForTable(tableId);
            bool isSplit = IsBillSplitForTable(tableId);

            paymentDAO.SavePayment(tableId, paymentMethod, amount, tip, vat, isSplit);
        }

        private decimal CalculateVAT(decimal amount)
        {
            // Logic to calculate VAT
        }

        private int GetTipForTable(int tableId)
        {
            // Logic to get tip for table
        }

        private bool IsBillSplitForTable(int tableId)
        {
            // Logic to check if bill is split for table
        }

    }
}
