using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.PaymentsDtos
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public decimal PaymentFee { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Ufe { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
