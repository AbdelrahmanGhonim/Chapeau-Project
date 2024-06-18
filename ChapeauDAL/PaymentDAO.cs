using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class PaymentDAO : BaseDao
    {
        public void SavePayment(int tableId, string paymentMethod, decimal amount, int tip, decimal vat, bool isSplit)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Payments (TableId, PaymentMethod, Amount, Tip, VAT, IsSplit, PaymentDate) VALUES (@TableId, @PaymentMethod, @Amount, @Tip, @VAT, @IsSplit, @PaymentDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableId", tableId);
                command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Tip", tip);
                command.Parameters.AddWithValue("@VAT", vat);
                command.Parameters.AddWithValue("@IsSplit", isSplit);
                command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
