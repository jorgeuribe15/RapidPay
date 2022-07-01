using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Data.PaymentsDtos
{
    public  class TransactionDTO
    {
        public int Id { get; set; }
        public int ClientCardId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TraansactionPlace { get; set; }

    }
}
