using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Payment
    {
        public string Feedback { get; set; }
        public int TableNumber { get; set; }
        public int PaymentHistoryID { get; set; }
        public decimal Tip { get; set; }
        public decimal TotalAmount { get; set; }

        public List<PaymentMethod> PaymentMethods;
        public DateTime Datetime { get; set; }

        public Payment() { }

        public Payment(int tableNumber, decimal totalAmount, decimal tip, string feedback, List<PaymentMethod> paymentMethods, DateTime dateTime)
        {
            this.TableNumber = tableNumber;
            this.PaymentMethods = paymentMethods;
            this.Feedback = feedback;
            this.Tip = tip;
            this.TotalAmount = totalAmount;
            this.Datetime = dateTime;
        }
    }
}
